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
			TransponderData td = new TransponderData ("14:00:00Z.000 T", "12345F", 100.5, -15.9, 6000, "GW400");
			//TODO:  need to figure out date stuff
			Assert.AreEqual ("12345F", td.Icao);
			Assert.AreEqual (100.5, td.Latitude);
			Assert.AreEqual (-15.9, td.Longitude);
			Assert.AreEqual (6000, td.Altitude);
			Assert.AreEqual ("GW400", td.SquawkCode);

		}
	}
}

