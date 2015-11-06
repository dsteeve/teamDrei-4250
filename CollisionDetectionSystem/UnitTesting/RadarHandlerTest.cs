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

			Aircraft us = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{.92, 0, 0}));
			us.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{5, 0, 0}));

			Aircraft them = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));
			them.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));

			dp.ThisAircraft = us;

			Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEventTest (them));

			//line for actually getting the first item in the vector double in a verctor double
			//Console.WriteLine ("us :" + (us.DataBuffer[us.DataBuffer.Count-1])[0]);

		}

		[Test ()]
		public void DistancePersonal ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (0.92, 0, 0);
			Vector<double> coordinate2 = utility.CalculateCoordinate (1, 0, 0);

			double distance = utility.Distance (coordinate1, coordinate2);
			Console.WriteLine (distance);
			distance *= 0.539956804;
			Console.WriteLine (distance);
			//Assert.AreEqual (111.405, distance);
		}
	}
}

