using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class Distances
	{
		[Test ]
		public void line50 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960210,-90.039798,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039793,-89.960214,3397);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			distance *= 0.539956804;	
			Console.WriteLine (distance);
			Assert.That (6.02, Is.LessThanOrEqualTo(distance));
			//distance is greater than 59.9 nm

			//	Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}	
		[Test ]
		public void line51 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960418,-90.039589,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039585,-89.960423,3395);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			distance *= 0.539956804;	
			Console.WriteLine (distance);
			Assert.That (5.99, Is.LessThanOrEqualTo(distance));
			//distance is greater than 59.9 nm

			//	Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}		

		[Test ]

		public void line52 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960418,-90.039589,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039377,-89.960631,3393);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			distance *= 0.539956804;	
			Console.WriteLine (distance);
			Assert.That (5.97, Is.LessThanOrEqualTo(distance));
			//distance is greater than 59.9 nm

			//	Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}

		[Test ]
		public void line52_53 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960627,-90.039381,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039168,-89.960840,3391);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			distance *= 0.539956804;	
			Console.WriteLine (distance);
			Assert.That (5.47, Is.LessThanOrEqualTo(distance));
			//distance is greater than 59.9 nm

			//	Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}
	}
}

