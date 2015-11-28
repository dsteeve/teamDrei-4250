using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class Distances
	{
		//testing that some random LLA calculations are within close proximity to ECEF calculations
		[Test ]
		public void DistanceCalc1 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960210,-90.039798,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039793,-89.960214,3397);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			Console.WriteLine (distance);
			Assert.That (Math.Abs(6.02 - distance) <= .01);

		}	
		[Test ]
		public void DistanceCalc2 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960418,-90.039589,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039585,-89.960423,3395);

			double distance = utility.Distance (coordinate1, coordinate2);
			Console.WriteLine (distance);
			Assert.That (Math.Abs(5.99 - distance) <= .01);

		}		

		[Test ]

		public void DistanceCalc3 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960418,-90.039589,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039377,-89.960631,3393);

			double distance = utility.Distance (coordinate1, coordinate2);
			Console.WriteLine (distance);
			Assert.That (Math.Abs(5.97 - distance) <= .01);

		}

		[Test ]
		public void DistanceCalc4 ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (39.960627,-90.039381,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40.039168,-89.960840,3391);

			double distance = utility.Distance (coordinate1, coordinate2);
			Console.WriteLine (distance);
			Assert.That (Math.Abs(5.94 - distance) <= .01);

		}
	}
}
