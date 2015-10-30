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
			TransponderData td = new TransponderData (100.5, -15.9, 0, "trial");
			Assert.AreEqual (100.5, td.Latitude);
			Assert.AreEqual (-15.9, td.Longitude);
			Assert.AreEqual (0, td.Altitude);
			Assert.AreEqual ("trial", td.Identifier);

		}
	}
}

