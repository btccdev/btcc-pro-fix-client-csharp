using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCCProFix.AccountInfoRelated
{
	public class AccReqID : StringField
	{
		public AccReqID()
			: base(8000)
		{

		}

		public AccReqID(string val)
			: base(8000, val)
		{

		}
	}
}
