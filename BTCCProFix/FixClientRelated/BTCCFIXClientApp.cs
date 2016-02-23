using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BTCCProFix.FixClientRelated
{
	class BTCCFIXClientApp : MessageCracker, IApplication
	{
		public ManualResetEvent Started = new ManualResetEvent(false);

		public SessionID m_sessionID { get; set; }

		#region Application Methods
		public void OnCreate(SessionID sessionID)
		{
			m_sessionID = sessionID;
		}

		public void OnLogon(SessionID sessionID)
		{

			Console.WriteLine("Logon - " + sessionID.ToString());

			Started.Set();
		}

		public void OnLogout(SessionID sessionID)
		{
			Console.WriteLine("Logout - " + sessionID.ToString());
		}

		public void FromAdmin(QuickFix.Message msg, SessionID sessionID)
		{
			Console.WriteLine("FromAdmin - " + msg.ToString() + "@" + sessionID.ToString());
		}

		public void ToAdmin(QuickFix.Message msg, SessionID sessionID)
		{
			Console.WriteLine("ToAdmin - " + msg.ToString() + "@" + sessionID.ToString());
		}

		public void ToApp(QuickFix.Message msg, SessionID sessionID)
		{
			Console.WriteLine("ToApp - " + msg.ToString() + "@" + sessionID.ToString());
		}

		public void FromApp(QuickFix.Message msg, SessionID sessionID)
		{
			Console.WriteLine("FromApp - " + msg.ToString() + "@" + sessionID.ToString());
			//try
			//{
			//	Crack(msg, sessionID);
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine("==Cracker exception==");
			//	Console.WriteLine(ex.ToString());
			//	Console.WriteLine(ex.StackTrace);
			//}
		}
		#endregion

		public void OnMessage(MarketDataIncrementalRefresh msg, SessionID sessionID)
		{
			FIX44XMLParser parser = new FIX44XMLParser();

			Console.WriteLine("==========Header::==========");
			Console.WriteLine(parser.getFieldName(Tags.BeginString.ToString()) + ":: " + msg.Header.GetString(Tags.BeginString));
			Console.WriteLine(parser.getFieldName(Tags.BodyLength.ToString()) + ":: " + msg.Header.GetString(Tags.BodyLength));
			Console.WriteLine(parser.getFieldName(Tags.MsgType.ToString()) + ":: MarketDataIncrementalRefresh (" + msg.Header.GetString(Tags.MsgType) + ")");
			Console.WriteLine(parser.getFieldName(Tags.MsgSeqNum.ToString()) + ":: " + msg.Header.GetString(Tags.MsgSeqNum));
			Console.WriteLine(parser.getFieldName(Tags.SenderCompID.ToString()) + ":: " + msg.Header.GetString(Tags.SenderCompID));
			Console.WriteLine(parser.getFieldName(Tags.SendingTime.ToString()) + ":: " + msg.Header.GetString(Tags.SendingTime));
			Console.WriteLine(parser.getFieldName(Tags.TargetCompID.ToString()) + ":: " + msg.Header.GetString(Tags.TargetCompID));

			Console.WriteLine("==========Body:: ==========");
			Console.WriteLine(parser.getFieldName(Tags.NoMDEntries.ToString()) + ":: " + msg.GetString(Tags.NoMDEntries));

			MarketDataIncrementalRefresh.NoMDEntriesGroup g0 = new MarketDataIncrementalRefresh.NoMDEntriesGroup();
			for (int grpIndex = 1; grpIndex <= msg.GetInt(Tags.NoMDEntries); grpIndex += 1)
			{
				Console.WriteLine("---------- ----------");
				msg.GetGroup(grpIndex, g0);
				//				Console.WriteLine(parser.getFieldName(Tags.MDUpdateAction.ToString())+":: "+g0.GetString(Tags.MDUpdateAction));

				Console.WriteLine(parser.getFieldName(Tags.MDUpdateAction.ToString()) + ":: " +
					parser.getFieldName(Tags.MDUpdateAction.ToString(), g0.GetString(Tags.MDUpdateAction).ToString()) +
					"(" + g0.GetString(Tags.MDUpdateAction) + ")"
				);

				Console.WriteLine(parser.getFieldName(Tags.MDEntryType.ToString()) + ":: " +
					parser.getFieldName(Tags.MDEntryType.ToString(), g0.GetString(Tags.MDEntryType).ToString()) +
					"(" + g0.GetString(Tags.MDEntryType) + ")"
				);

				try
				{
					Console.WriteLine(parser.getFieldName(Tags.MDEntryPx.ToString()) + ":: " + g0.GetString(Tags.MDEntryPx));
				}
				catch (Exception ex)
				{
					Console.WriteLine(parser.getFieldName(Tags.MDEntrySize.ToString()) + ":: " + g0.GetString(Tags.MDEntrySize));
				}

				Console.WriteLine(parser.getFieldName(Tags.MDEntryDate.ToString()) + ":: " + g0.GetString(Tags.MDEntryDate));
				Console.WriteLine(parser.getFieldName(Tags.MDEntryTime.ToString()) + ":: " + g0.GetString(Tags.MDEntryTime));
			}

			Console.WriteLine("==========Trailer:: ==========");
			Console.WriteLine(parser.getFieldName(Tags.CheckSum.ToString()) + ":: " + msg.Trailer.GetString(Tags.CheckSum));
		}

		public void OnMessage(MarketDataSnapshotFullRefresh msg, SessionID sessionID)
		{
			FIX44XMLParser parser = new FIX44XMLParser();

			Console.WriteLine("==========Header::==========");
			Console.WriteLine(parser.getFieldName(Tags.BeginString.ToString()) + ":: " + msg.Header.GetString(Tags.BeginString));
			Console.WriteLine(parser.getFieldName(Tags.BodyLength.ToString()) + ":: " + msg.Header.GetString(Tags.BodyLength));
			Console.WriteLine(parser.getFieldName(Tags.MsgType.ToString()) + ":: MarketDataSnapshotFullRefresh (" + msg.Header.GetString(Tags.MsgType) + ")");
			Console.WriteLine(parser.getFieldName(Tags.MsgSeqNum.ToString()) + ":: " + msg.Header.GetString(Tags.MsgSeqNum));
			Console.WriteLine(parser.getFieldName(Tags.SenderCompID.ToString()) + ":: " + msg.Header.GetString(Tags.SenderCompID));
			Console.WriteLine(parser.getFieldName(Tags.SendingTime.ToString()) + ":: " + msg.Header.GetString(Tags.SendingTime));
			Console.WriteLine(parser.getFieldName(Tags.TargetCompID.ToString()) + ":: " + msg.Header.GetString(Tags.TargetCompID));

			Console.WriteLine("==========Body:: ==========");
			Console.WriteLine(parser.getFieldName(Tags.Symbol.ToString()) + ":: " + msg.GetString(Tags.Symbol));
			Console.WriteLine(parser.getFieldName(Tags.NoMDEntries.ToString()) + ":: " + msg.GetString(Tags.NoMDEntries));

			MarketDataSnapshotFullRefresh.NoMDEntriesGroup g0 = new MarketDataSnapshotFullRefresh.NoMDEntriesGroup();
			for (int grpIndex = 1; grpIndex <= msg.GetInt(Tags.NoMDEntries); grpIndex += 1)
			{
				Console.WriteLine("---------- ----------");
				msg.GetGroup(grpIndex, g0);
				Console.WriteLine(parser.getFieldName(Tags.MDEntryType.ToString()) + ":: " +
					parser.getFieldName(Tags.MDEntryType.ToString(), g0.GetString(Tags.MDEntryType).ToString()) +
					"(" + g0.GetString(Tags.MDEntryType) + ")"
				);

				try
				{
					Console.WriteLine(parser.getFieldName(Tags.MDEntryPx.ToString()) + ":: " + g0.GetString(Tags.MDEntryPx));
				}
				catch (Exception ex)
				{
					Console.WriteLine(parser.getFieldName(Tags.MDEntrySize.ToString()) + ":: " + g0.GetString(Tags.MDEntrySize));
				}

				Console.WriteLine(parser.getFieldName(Tags.MDEntryDate.ToString()) + ":: " + g0.GetString(Tags.MDEntryDate));
				Console.WriteLine(parser.getFieldName(Tags.MDEntryTime.ToString()) + ":: " + g0.GetString(Tags.MDEntryTime));
			}

			Console.WriteLine("==========Trailer:: ==========");
			Console.WriteLine(parser.getFieldName(Tags.CheckSum.ToString()) + ":: " + msg.Trailer.GetString(Tags.CheckSum));

		}
	}
}
