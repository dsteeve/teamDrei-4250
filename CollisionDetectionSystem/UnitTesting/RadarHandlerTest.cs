using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class RadarHandlerTest
	{
		/*	
		 *  	This class is split into test the radar events and the tests for the cordinates being fed in
		 */ 

		[Test ()]
		public void AircraftDidEnterRadarRangeEventTestLat ()
		{
			
			RadarHandler rh = new RadarHandler ();

			Aircraft us = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			us.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40.037919,-89,3000}));

			Aircraft them = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			them.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{39.962085,-89,3000}));

			//test one, should be about 4.5nm appart on radar, true since it is in the 6nm radius, latitude test
			Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEventTest (them));
		}		

		[Test ]
		public void AircraftDidEnterRadarRangeEventTestLong ()
		{
			
			RadarHandler rh = new RadarHandler ();

			Aircraft us = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			us.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40,-89,3000}));

			Aircraft them = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			them.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40,-89.09053,3000}));

			//test one, should be about 4.6nm appart, true since it is in the 6nm radius, longitude test
			Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEventTest (them));
		}		

		[Test ]
		public void AircraftDidEnterRadarRangeEventTestAlt ()
		{
			
			RadarHandler rh = new RadarHandler ();

			Aircraft us = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			us.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40,-89,3000}));

			Aircraft them = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			them.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40,-89,10000}));

			//test one, should be about 3.78nm appart, true since it is in the 6nm radius, altitude test
			Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEventTest (them));
		}


		/*
		 * 	Test for cordinates
		 * 	//0.075834 degrees in lat.== 5.232546 miles == 4.5469 nm
		 */

		[Test ]
		public void DistancePersonalLat ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40.037919,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (39.962085,-89,3000); 

			double distance = utility.Distance (coordinate1, coordinate2);
			Console.WriteLine("distance personalAlt: " + distance);

			Assert.That (4.54, Is.LessThan(distance));
			Assert.That (4.55, Is.GreaterThan (distance));

		}		

		[Test ]
		//.09053 difference in long 
		public void DistancePersonalLong ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40,-89.09053,3000);

			double distance = utility.Distance (coordinate1, coordinate2); 
			Console.WriteLine("distance personalLong: " + distance);
			Assert.That (4.174, Is.LessThan(distance));
			Assert.That (4.176, Is.GreaterThan(distance));
		}		

		[Test ]
		public void DistancePersonalAlt ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40,-89,10000);

			double distance = utility.Distance (coordinate1, coordinate2); //
			Console.WriteLine("distance personalAlt: " + distance);
			Assert.That (1.15, Is.LessThan(distance));
			Assert.That (1.16, Is.GreaterThan (distance));

		}		

		[Test ]
		public void DistancePersonalRandom ()
		{
			//distance is around  59.9 nm
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (41,-89,3000);

			double distance = utility.Distance (coordinate1, coordinate2); 
			Console.WriteLine (distance);
			Console.WriteLine("distance personalRand: " + distance);
			Assert.That (59.96, Is.LessThanOrEqualTo(distance));
			Assert.That (59.97, Is.GreaterThanOrEqualTo(distance));

		}
	}
}

