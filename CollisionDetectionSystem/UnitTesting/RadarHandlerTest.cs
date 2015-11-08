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
		 *  	This class is split into tesiint radar events and the tests for the cordinates being fed in
		 */ 

		//line for actually getting the first item in the vector double in a verctor double
		//Console.WriteLine ("us :" + (us.DataBuffer[us.DataBuffer.Count-1])[0]);

		[Test ()]
		public void AircraftDidEnterRadarRangeEventTestLat ()
		{
			DataProcessor dp = new DataProcessor ();
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
			DataProcessor dp = new DataProcessor ();
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
			DataProcessor dp = new DataProcessor ();
			RadarHandler rh = new RadarHandler ();

			Aircraft us = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			us.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40,-89,3000}));

			Aircraft them = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{.002, 0, 0}));
			them.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{40,-89,10000}));

			//test one, should be about 3.78nm appart, true since it is in the 6nm radius, altitude test
			Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEventTest (them));
		}


		/*
		 * 	Test for cordinates being fed in above, I'm not sure the altitude one shoud be that much different in altitude.
		 * 	
		 */

		[Test ]
		public void DistancePersonalLat ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40.037919,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (39.962085,-89,3000);

			double distance = utility.Distance (coordinate1, coordinate2);//8.424km
			distance *= 0.539956804;

			double difference = Math.Abs(distance * .00001);

			// had to do it this way because a straight comparison was not working
			Assert.That(Math.Abs(distance -  4.548596116896),  Is.LessThanOrEqualTo(difference), "greater than");
		}		

		[Test ]
		public void DistancePersonalLong ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40,-89.09053,3000);

			double distance = utility.Distance (coordinate1, coordinate2); //7.735km
			distance *= 0.539956804;
			Assert.AreEqual (4.17656587894, distance);
		}		

		[Test ]
		public void DistancePersonalAlt ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (40,-89,10000);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			distance *= 0.539956804;	
			Assert.AreEqual (3.779697628, distance);


			//	Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}		

		[Test ]
		public void DistancePersonalRandom ()
		{
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> coordinate1 = utility.CalculateCoordinate (40,-89,3000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (41,-89,3000);

			double distance = utility.Distance (coordinate1, coordinate2); //7km
			distance *= 0.539956804;	
			Console.WriteLine (distance);
			Assert.That (59.9, Is.LessThanOrEqualTo(distance));
			//distance is greater than 59.9 nm

			//	Assert.AreEqual (true, rh.AircraftDidEnterRadarRangeEvent (them));
		}
	}
}

