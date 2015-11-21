using NUnit.Framework;
using System;
using CollisionDetectionSystem;
using System.Collections.Generic;

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

		[Test]
		public void startTest ()
		{
			String path = System.IO.Directory.GetCurrentDirectory ();

			path = path.Split (new String[]{ "UnitTesting\\" }, StringSplitOptions.None) [0] +
				"SystemTesting\\TestData\\SystemTests\\TestFiles\\1";
			String argument = "testdir=" + path;

			unit.Start (StringUtility.getArgValue(argument));

			Assert.True(true);
		}

		[Test]
		public void streamReadersTest ()
		{
			String path = System.IO.Directory.GetCurrentDirectory ();

			path = path.Split (new String[]{ "UnitTesting\\" }, StringSplitOptions.None) [0] +
				"SystemTesting\\TestData\\SystemTests\\TestFiles\\1";
			String argument = "testdir=" + path;

			var readers = unit.streamReaders (StringUtility.getArgValue(argument));

			Assert.AreEqual ("#Speed is near: 113.43 nautical miles per hour" , readers[0].ReadLine());
			Assert.AreEqual ("#Speed is near: 113.46 nautical miles per hour" , readers[1].ReadLine());
		}

		[Test]
		public void buildTransporterDataListTest ()
		{
			String path = System.IO.Directory.GetCurrentDirectory ();

			path = path.Split (new String[]{ "UnitTesting\\" }, StringSplitOptions.None) [0] +
				"SystemTesting\\TestData\\SystemTests\\TestFiles\\1";
			String argument = "testdir=" + path;

			var list = unit.buildTransporterDataList (StringUtility.getArgValue(argument));

			Assert.AreEqual ("11/20/2015 12:00:00 PM", list[3].PingTimestamp.ToString());
			Assert.AreEqual ("CE64B2", list[0].Icao.ToString());
			Assert.AreEqual (40.050000, list[0].Latitude);
			Assert.AreEqual (-89.950000, list[0].Longitude);
			Assert.AreEqual (3500, list[0].Altitude);
			Assert.AreEqual ("00HN00", list[0].SquawkCode.ToString());

			Assert.AreEqual ("11/20/2015 12:00:00 PM", list[1].PingTimestamp.ToString());
			Assert.AreEqual ("B1E24F", list[1].Icao.ToString());
			Assert.AreEqual (39.950000, list[1].Latitude);
			Assert.AreEqual (-90.050000, list[1].Longitude);
			Assert.AreEqual (3000, list[1].Altitude);
			Assert.AreEqual ("AE1200", list[1].SquawkCode.ToString());
		}


		[Test]
		public void sendDataTest ()
		{
			String path = System.IO.Directory.GetCurrentDirectory ();

			path = path.Split (new String[]{ "UnitTesting\\" }, StringSplitOptions.None) [0] +
				"SystemTesting\\TestData\\SystemTests\\TestFiles\\1";
			String argument = "testdir=" + path;

			var list = unit.buildTransporterDataList (StringUtility.getArgValue(argument));

			list = unit.sendData (list);

			Assert.AreEqual ("12:00:00Z.500 T", list[0].Timestamp.ToString());
			Assert.AreEqual ("CE64B2", list[0].Icao.ToString());
			Assert.AreEqual (40.049792, list[0].Latitude);
			Assert.AreEqual (-89.950208, list[0].Longitude);
			Assert.AreEqual (3497, list[0].Altitude);
			Assert.AreEqual ("00HN00", list[0].SquawkCode.ToString());

			Assert.AreEqual ("12:00:00Z.500 T", list[1].Timestamp.ToString());
			Assert.AreEqual ("B1E24F", list[1].Icao.ToString());
			Assert.AreEqual (39.950208, list[1].Latitude);
			Assert.AreEqual (-90.049792, list[1].Longitude);
			Assert.AreEqual (3000, list[1].Altitude);
			Assert.AreEqual ("AE1200", list[1].SquawkCode.ToString());
		}
	}
}

