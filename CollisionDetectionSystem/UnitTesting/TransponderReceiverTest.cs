using NUnit.Framework;
using System;
using CollisionDetectionSystem;
using System.Collections.Generic;

namespace UnitTesting
{
	[TestFixture ()]
	public class TransponderReceiverTest
	{
		Boolean postDataEventFired = false;
		 
		private ITransponderReceiver TransponderReceiver { get; set; }

		private TransponderReceiver unit = new TransponderReceiver ();

		//inner wireup to test event is fired
		public void GotPostDataEvent(  TransponderData td) {
			this.postDataEventFired = true;
		}


		[TestFixtureSetUp] 
		public void Init() {
			postDataEventFired = false;
			unit.PostDataEvent += this.GotPostDataEvent;
		}


		[Test ()]
		public void gotGoodData ()
		{
			Assert.IsFalse (postDataEventFired);
			TransponderData td = new TransponderData ("14:00:00Z.253 T", "12345F", 100.5, -15.9, 6000, "GW400");
			//var list1 = new List<TransponderData> ();
			//list1.Add (td);
	
			unit.ReceiveData (td);
			//Test that we fired the postDataEvent
			Assert.IsTrue (postDataEventFired);

		}

		[Test ()]
		public void gotBadDateInData ()
		{
			Assert.IsFalse (postDataEventFired);
			TransponderData td = new TransponderData ("xxxx", "12345F", 100.5, -15.9, 6000, "GW400");
			//var list1 = new List<TransponderData> ();
			TransponderReceiver unit = new TransponderReceiver ();
			//list1.Add (td);

			unit.ReceiveData (td);
			//Test that we didn't fire the postDataEvent if we got bad data, it should log and ignore.
			Assert.IsFalse (postDataEventFired);

		}
	}
}

