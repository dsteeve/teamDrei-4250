using NUnit.Framework;
using System;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class MockTransponderTest
	{
		Boolean broadedCastedData = false;

		private IMockTransponder MockTransponder { get; set; }

		private MockTransponder unit = new MockTransponder ();


		public void GotSendDataEvent(TransponderData td) {
			this.broadedCastedData = true;
		}


		[TestFixtureSetUp] 
		public void Init() {
			broadedCastedData = false;
			unit.SendDataEvent += this.GotSendDataEvent;
		}


		[Test ()]
		public void gotGoodFile ()
		{
			Assert.IsFalse (broadedCastedData);
			unit.Start ("goodfilename");

			//Test that we fired the sendDataEvent
			Assert.IsTrue (broadedCastedData);

		}


	}
}

