using NUnit.Framework;
using System;
using CollisionDetectionSystem;
using System.Collections.Generic;
using System.IO;

namespace UnitTesting
{
	[TestFixture ()]
	public class MockTransponderTest
	{
		Boolean broadedCastedData = false;

		private IMockTransponder MockTransponder { get; set; }

		private MockTransponder unit = new MockTransponder ();


		public void GotSendDataEvent(List<TransponderData> tdlist) {
			this.broadedCastedData = true;
		}

		private String buildTestDir(){
			
			String path = System.IO.Directory.GetCurrentDirectory ();
			String [] pieces = path.Split (new String[]{ "UnitTesting"  }, StringSplitOptions.None);
			path = pieces[0] + 
				"SystemTesting" +  Path.DirectorySeparatorChar 
				+ "TestData" +   Path.DirectorySeparatorChar
				+ "SystemTests" +  Path.DirectorySeparatorChar + 
				"TestFiles" +  Path.DirectorySeparatorChar + "testReadFile";
			Console.WriteLine ("path: " + path);
			return path;
		}


		[TestFixtureSetUp] 
		public void Init() {
			broadedCastedData = false;
			unit.SendDataEvent += this.GotSendDataEvent;
		}


		[Test ()]
		public void gotGoodFile ()
		{
			String dirname = buildTestDir();

			Assert.IsFalse (broadedCastedData);
			unit.Start (dirname);

			//Test that we fired the sendDataEvent
			Assert.IsTrue (broadedCastedData);

		}
			

		[Test]
		public void streamReadersTest ()
		{
			
			String argument = "testdir=" +  buildTestDir();

			var readers = unit.streamReaders (StringUtility.getArgValue(argument));

			Assert.AreEqual ("#Speed is near: 113.43 nautical miles per hour" , readers[0].ReadLine());
			Assert.AreEqual ("#Speed is near: 113.46 nautical miles per hour" , readers[1].ReadLine());
		}

		[Test]
		public void buildTransporterDataListTest ()
		{
			String argument = "testdir=" + buildTestDir();

			var list = unit.buildTransporterDataList (StringUtility.getArgValue(argument));

			DateTime time = DateTime.Parse("12:00:00.000");

			Assert.AreEqual (time, list[0].PingTimestamp);
			Assert.AreEqual ("CE64B2", list[0].Icao.ToString());
			Assert.AreEqual (40.050000, list[0].Latitude);
			Assert.AreEqual (-89.950000, list[0].Longitude);
			Assert.AreEqual (3500, list[0].Altitude);
			Assert.AreEqual ("00HN00", list[0].SquawkCode.ToString());

			Assert.AreEqual (time, list[1].PingTimestamp);
			Assert.AreEqual ("B1E24F", list[1].Icao.ToString());
			Assert.AreEqual (39.950000, list[1].Latitude);
			Assert.AreEqual (-90.050000, list[1].Longitude);
			Assert.AreEqual (3000, list[1].Altitude);
			Assert.AreEqual ("AE1200", list[1].SquawkCode.ToString());
		}


		[Test]
		public void sendDataTest ()
		{
			String argument = "testdir=" + buildTestDir();

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

