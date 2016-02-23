using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCCProFix.AccountInfoRelated
{
	internal class AccountInfoRequest : QuickFix.FIX44.Message
	{
		public const String MSGTYPE = "U1000";
		public AccountInfoRequest()
			: base()
		{
			Header.SetField(new MsgType(MSGTYPE));
		}

		public Account getAccount()
		{
			return get(new Account());
		}

		public Account get(Account value)
		{
			GetField(value);
			return value;
		}

		public AccReqID get(AccReqID value)
		{
			GetField(value);
			return value;
		}

		public AccReqID getAccReqID()
		{
			AccReqID value = new AccReqID();
			GetField(value);

			return value;
		}

		public void set(AccReqID value)
		{
			SetField(value);
		}

		public void set(Account value)
		{
			SetField(value);
		}

		public static AccountInfoRequest CreateAccountInfoRequest(string account, string accReqID)
		{
			AccountInfoRequest accountInfoRequest = new AccountInfoRequest();

			accountInfoRequest.set(new Account(account));
			accountInfoRequest.set(new AccReqID(accReqID));
			return accountInfoRequest;
		}
	}
}
