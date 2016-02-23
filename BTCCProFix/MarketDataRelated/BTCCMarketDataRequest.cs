using QuickFix.Fields;
using QuickFix.FIX44;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCCProFix.MarketDataRelated
{
	class BTCCMarketDataRequest
	{
		public MarketDataRequest marketDataFullSnapRequest(string symbol)
		{
			MarketDataRequest tickerRequest = new MarketDataRequest();

			MarketDataRequest.NoRelatedSymGroup symbolGroup = new MarketDataRequest.NoRelatedSymGroup();
			symbolGroup.SetField(new Symbol(symbol));
			tickerRequest.AddGroup(symbolGroup);

			tickerRequest.Set(new MDReqID("123"));
			tickerRequest.Set(new SubscriptionRequestType('0'));
			tickerRequest.Set(new MarketDepth(0));

			addMDType(tickerRequest, '0');
			addMDType(tickerRequest, '1');
			addMDType(tickerRequest, '2');
			addMDType(tickerRequest, '3');
			addMDType(tickerRequest, '4');
			addMDType(tickerRequest, '5');
			addMDType(tickerRequest, '6');
			addMDType(tickerRequest, '7');
			addMDType(tickerRequest, '8');
			addMDType(tickerRequest, '9');
			addMDType(tickerRequest, 'A');
			addMDType(tickerRequest, 'B');
			addMDType(tickerRequest, 'C');

			return tickerRequest;
		}

		public MarketDataRequest marketDataIncrementalRequest(string symbol)
		{
			MarketDataRequest tickerRequest = new MarketDataRequest();

			MarketDataRequest.NoRelatedSymGroup symbolGroup = new MarketDataRequest.NoRelatedSymGroup();
			symbolGroup.SetField(new Symbol(symbol));
			tickerRequest.AddGroup(symbolGroup);

			tickerRequest.Set(new MDReqID("123"));
			tickerRequest.Set(new SubscriptionRequestType('1'));
			tickerRequest.Set(new MarketDepth(0));

			addMDType(tickerRequest, '0');
			addMDType(tickerRequest, '1');
			addMDType(tickerRequest, '2');
			addMDType(tickerRequest, '3');
			addMDType(tickerRequest, '4');
			addMDType(tickerRequest, '5');
			addMDType(tickerRequest, '6');
			addMDType(tickerRequest, '7');
			addMDType(tickerRequest, '8');
			addMDType(tickerRequest, '9');
			addMDType(tickerRequest, 'A');
			addMDType(tickerRequest, 'B');
			addMDType(tickerRequest, 'C');

			return tickerRequest;
		}

		public MarketDataRequest unsubscribeIncrementalRequest(string symbol)
		{
			MarketDataRequest tickerRequest = new MarketDataRequest();

			MarketDataRequest.NoRelatedSymGroup symbolGroup = new MarketDataRequest.NoRelatedSymGroup();
			symbolGroup.SetField(new Symbol(symbol));
			tickerRequest.AddGroup(symbolGroup);

			tickerRequest.Set(new MDReqID("123"));
			tickerRequest.Set(new SubscriptionRequestType('2'));
			tickerRequest.Set(new MarketDepth(0));

			addMDType(tickerRequest, '0');
			addMDType(tickerRequest, '1');
			addMDType(tickerRequest, '2');
			addMDType(tickerRequest, '3');
			addMDType(tickerRequest, '4');
			addMDType(tickerRequest, '5');
			addMDType(tickerRequest, '6');
			addMDType(tickerRequest, '7');
			addMDType(tickerRequest, '8');
			addMDType(tickerRequest, '9');
			addMDType(tickerRequest, 'A');
			addMDType(tickerRequest, 'B');
			addMDType(tickerRequest, 'C');

			return tickerRequest;
		}

		private static void addMDType(MarketDataRequest tickerRequest, char type)
		{
			MarketDataRequest.NoMDEntryTypesGroup g0 = new MarketDataRequest.NoMDEntryTypesGroup();
			g0.Set(new MDEntryType(type));
			tickerRequest.AddGroup(g0);
		}
	}
}
