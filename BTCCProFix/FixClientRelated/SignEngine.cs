using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpotFix.FixClientRelated
{
	internal class SignEngine
	{
		private static long CurrentTimeStamp()
		{
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
		}

		private static string ByteToString(byte[] buff)
		{
			StringBuilder sbinary = new StringBuilder();

			for (int i = 0; i < buff.Length; i++)
				sbinary.Append(buff[i].ToString("X2").ToLower()); // hex format

			return sbinary.ToString();
		}


		private static string GetSignature(string data,string key)
		{
			HMACSHA1 hmacsha1 = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(key));
			byte[] signatureByte = hmacsha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(data));
			return ByteToString(signatureByte);
		}

		public static string GetAccountString(string accessKey, string secretKey)
		{
			string methodstr = "method=getForwardsAccountInfo&params=";
			string tonce = "" + CurrentTimeStamp() * 1000;
			string param = "tonce=" + tonce + "&accesskey=" + accessKey + "&requestmethod=post&id=1&" + methodstr;

			string hash = GetSignature(param, secretKey);
			string basicAuth = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(accessKey + ":" + hash)));

			return string.Format("{0}:{1}", tonce, basicAuth);
		}
	}
}
