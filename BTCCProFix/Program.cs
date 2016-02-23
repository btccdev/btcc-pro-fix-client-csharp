// include QuickFix.dll in your project 
using System;
using System.Collections.Generic;
using System.Xml;
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;
using BTCCProFix.AccountInfoRelated;
using BTCCProFix.FixClientRelated;
using BTCCProFix.MarketDataRelated;
using SpotFix.FixClientRelated;


namespace BTCCProFix
{
	static class Constants
	{
		//public const string BITCOIN = "BTCCNY";
		public const string BITCOIN = "XBTCNY";
		public const string FIX_XML_PATH = "selfFIX44.xml";
		//public const string FIX_XML_PATH = "FIX.4.4.xml";

		// your access key
		public const string ACCESSKEY = "";

		// your secret key
		public const string SECRET_KEY = "";
	}



	class MainClass
	{
		public static void Main(string[] args)
		{
			BTCCFIXClientApp app = new BTCCFIXClientApp();
			string sessionFile = "session_client.txt";
			SessionSettings settings = new SessionSettings(sessionFile);
			IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
			ILogFactory logFactory = new FileLogFactory(settings);
			QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(app, storeFactory, settings, logFactory);
			initiator.Start();

			BTCCMarketDataRequest btccDataRequest = new BTCCMarketDataRequest();

			app.Started.WaitOne();

			//send accountinfo request
			AccountInfoRequest accountRequest = AccountInfoRequest.CreateAccountInfoRequest(SignEngine.GetAccountString(Constants.ACCESSKEY, Constants.SECRET_KEY), "request450");
			bool ret = Session.SendToTarget(accountRequest, app.m_sessionID);

			Console.WriteLine("SendToTarget ret={0}", ret);

			//request full snapshot
			//MarketDataRequest dataRequest = btccDataRequest.marketDataFullSnapRequest(Constants.BITCOIN);
			//bool ret = Session.SendToTarget(accountRequest, app.m_sessionID);

			//Console.WriteLine("SendToTarget ret={0}", ret);

			//			dataRequest = btccDataRequest.marketDataFullSnapRequest("LTCCNY");
			//			ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//			Console.WriteLine("SendToTarget ret={0}", ret);

			//			dataRequest = btccDataRequest.marketDataFullSnapRequest("LTCBTC");
			//			ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//			Console.WriteLine("SendToTarget ret={0}", ret);

			//System.Threading.Thread.Sleep(15000);
			//request incremental request
			//dataRequest = btccDataRequest.marketDataIncrementalRequest(Constants.BITCOIN);
			//ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//Console.WriteLine("SendToTarget ret={0}", ret);

			//			dataRequest = btccDataRequest.marketDataIncrementalRequest("LTCCNY");
			//			ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//			Console.WriteLine("SendToTarget ret={0}", ret);

			//			dataRequest = btccDataRequest.marketDataIncrementalRequest("LTCBTC");
			//			ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//			Console.WriteLine("SendToTarget ret={0}", ret);

			//System.Threading.Thread.Sleep(40000);
			////unsubscribe incremental request
			////dataRequest = btccDataRequest.unsubscribeIncrementalRequest(Constants.BITCOIN);
			//ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//Console.WriteLine("SendToTarget ret={0}", ret);

			//			dataRequest = btccDataRequest.unsubscribeIncrementalRequest("LTCCNY");
			//			ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//			Console.WriteLine("SendToTarget ret={0}", ret);

			//			dataRequest = btccDataRequest.unsubscribeIncrementalRequest("LTCBTC");
			//			ret = Session.SendToTarget(dataRequest, app.m_sessionID);
			//			Console.WriteLine("SendToTarget ret={0}", ret);
		}
	}
}