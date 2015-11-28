using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class TransponderDataTest
	{
		//TODO:  need to figure out date stuff
		//fyi: I would pull out the Z and the T in the date by replacing them with a blank then right trim the string and 
		//convert it to a date. The only reason the Z and T are in the time is because its in our example data. For this
		//project I do not think it matters.

		//TODO:  in real life it would be possible to get letters in for the numeric numbers if someone's transponder was spewing bad data.
		//we shouldn't blow up on that.


		[Test ()]
		public void testGoodData ()
		{
			TransponderData td = new TransponderData ("14:00:00Z.253 T", "12345F", 100.5, -15.9, 6000, "GW400");

			DateTime time = DateTime.Parse("14:00:00.253");
			Console.WriteLine (time.Millisecond);
			Assert.AreEqual (time, td.PingTimestamp);
			Assert.AreEqual ("12345F", td.Icao);
			Assert.AreEqual (100.5, td.Latitude);
			Assert.AreEqual (-15.9, td.Longitude);
			Assert.AreEqual (6000, td.Altitude);
			Assert.AreEqual ("GW400", td.SquawkCode);

		}

		[Test ()]
		public void testBadDataCantParse ()
		{
			TransponderData td = new TransponderData ("10:00Z.253 T", "12345F", 100.5, -15.9, 6000, "GW400");

			Assert.IsNull (td.PingTimestamp);
			Assert.AreEqual ("12345F", td.Icao);
			Assert.AreEqual (100.5, td.Latitude);
			Assert.AreEqual (-15.9, td.Longitude);
			Assert.AreEqual (6000, td.Altitude);
			Assert.AreEqual ("GW400", td.SquawkCode);

		}

		[Test ()]
		public void testOutOfRangeLats ()
		{
			TransponderData td = new TransponderData ("14:00:00Z.253 T", "12345F", -7200000, -15.9, 6000, "GW400");

			DateTime time = DateTime.Parse("14:00:00.253");
			Console.WriteLine (time.Millisecond);
			Assert.AreEqual (time, td.PingTimestamp);
			Assert.AreEqual ("12345F", td.Icao);
			Assert.AreEqual (-7200000, td.Latitude);
			Assert.AreEqual (-15.9, td.Longitude);
			Assert.AreEqual (6000, td.Altitude);
			Assert.AreEqual ("GW400", td.SquawkCode);

		}

		[Test ()]
		public void testOutOfRangeLong ()
		{
			TransponderData td = new TransponderData ("14:00:00Z.253 T", "12345F", -7200000, -1000005.3333, 6000, "GW400");

			DateTime time = DateTime.Parse("14:00:00.253");
			Console.WriteLine (time.Millisecond);
			Assert.AreEqual (time, td.PingTimestamp);
			Assert.AreEqual ("12345F", td.Icao);
			Assert.AreEqual (-7200000, td.Latitude);
			Assert.AreEqual (-1000005.3333, td.Longitude);
			Assert.AreEqual (6000, td.Altitude);
			Assert.AreEqual ("GW400", td.SquawkCode);

		}

		[Test ()]
		public void transponderData2String ()
		{
			TransponderData td = new TransponderData ("14:00:00Z.253 T", "12345F", -7200000, -1000005.3333, 6000, "GW400");

			String tdString = td.ToString ();
			Console.WriteLine ("tdata to string --" + tdString);
			Assert.True (tdString.Contains("ICAO:12345F"));
			Assert.True (tdString.Contains("Latitude:-7200000"));
			Assert.True (tdString.Contains("Longitude:-1000005.3333"));
			Assert.True (tdString.Contains("Altitude:6000"));

		}
	}
}

