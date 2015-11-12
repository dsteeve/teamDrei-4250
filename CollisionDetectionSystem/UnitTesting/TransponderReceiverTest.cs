﻿using NUnit.Framework;
using System;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class TransponderReceiverTest
	{
		Boolean postDataEventFired = false;
		 
		private ITransponderReceiver TransponderReceiver { get; set; }

		private TransponderReceiver unit = new TransponderReceiver ();


		public void GotPostDataEvent(TransponderData td) {
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
	
			unit.ReceiveData (td);
			//Test that we fired the postDataEvent
			Assert.IsTrue (postDataEventFired);

		}

		[Test ()]
		public void gotBadDateInData ()
		{
			Assert.IsFalse (postDataEventFired);
			TransponderData td = new TransponderData ("xxxx", "12345F", 100.5, -15.9, 6000, "GW400");
			TransponderReceiver unit = new TransponderReceiver ();
			unit.ReceiveData (td);
			//Test that we didn't fire the postDataEvent if we got bad data, it should log and ignore.
			Assert.IsFalse (postDataEventFired);

		}
	}
}
