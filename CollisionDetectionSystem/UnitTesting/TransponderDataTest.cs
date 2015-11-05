using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class TransponderDataTest
	{
		[Test ()]
		public void TransponderData ()
		{
			TransponderData td = new TransponderData ("14:00:00Z.253 T", "12345F", 100.5, -15.9, 6000, "GW400");
			//TODO:  need to figure out date stuff
			//fyi: I would pull out the Z and the T in the date by replacing them with a blank then right trim the string and 
			//convert it to a date. The only reason the Z and T are in the time is because its in our example data. For this
			//project I do not think it matters.
			DateTime time = DateTime.Parse("14:00:00.253");
			Console.WriteLine (time.Millisecond);
			Assert.AreEqual (time, td.PingTimestamp);
			Assert.AreEqual ("12345F", td.Icao);
			Assert.AreEqual (100.5, td.Latitude);
			Assert.AreEqual (-15.9, td.Longitude);
			Assert.AreEqual (6000, td.Altitude);
			Assert.AreEqual ("GW400", td.SquawkCode);

		}
	}
}

