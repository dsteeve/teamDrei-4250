using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class RadarHandlerTest
	{
		[Test ()]
		public void AircraftDidEnterRadarRangeEventTest ()
		{
			DataProcessor dp = new DataProcessor ();
			RadarHandler rh = new RadarHandler ();

			Aircraft us = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{5, 0, 0}));
			us.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{5, 0, 0}));

			Aircraft them = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));
			them.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{1, 5, 0}));

			dp.ThisAircraft = us;

			Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}
	}
}

