﻿using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class MathCalcUtilityTest
	{
		[Test ()]
		public void CalculateVectorTest ()
		{
			
			//Logical data test
			MathCalcUtility utility = new MathCalcUtility ();

			Vector<double> data1 = Vector<double>.Build.DenseOfArray(new double[3]{1, 2, 3});
			Vector<double> data2 = Vector<double>.Build.DenseOfArray(new double[3]{3, 5, 4});

			Vector<double> vec = utility.CalculateVector (data1, data2);

			Assert.AreEqual (2.0, vec[0]);
			Assert.AreEqual (3.0, vec[1]);
			Assert.AreEqual (1.0, vec [2]);

			//Real data test
			data1 = Vector<double>.Build.DenseOfArray(new double[3]{51.5033630, -0.1276250, 500});
			data2 = Vector<double>.Build.DenseOfArray(new double[3]{51.5033635, -0.1276255, 510});

			vec = utility.CalculateVector (data1, data2);

			Assert.AreEqual (0.0000005, vec[0]);
			Assert.AreEqual (-0.0000005, vec[1]);
			Assert.AreEqual (10.0, vec [2]);
		}

		[Test ()]
		public void LLAtoECEFtest(){
			
			MathCalcUtility utility = new MathCalcUtility ();
			Vector<double> result = utility.CalculateCoordinate (34.0522, -118.40806, 0);

			Assert.AreEqual (-1358.9179, result[0]);
			Assert.AreEqual (-2512.4215, result[1]);
			Assert.AreEqual (1917.5196, result[2]);

			Vector<double> result2 = utility.CalculateCoordinate (100, 100, 100);

			Assert.AreEqual (104.1863, result2 [0]);
			Assert.AreEqual (-590.8690, result2 [1]);
			Assert.That (3379.9002, Is.LessThan (result2 [2]));
			Assert.That (3379.91, Is.GreaterThan (result2 [2]));


		}

		[Test()]
		public void DistanceTest(){

			//Test 1
			MathCalcUtility utility = new MathCalcUtility ();
			Vector<double> coordinate1 = utility.CalculateCoordinate (0, 1, 5000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (0, 0, 5000);

			double distance = utility.Distance (coordinate1, coordinate2);

			Assert.That (60.1, Is.LessThan (distance));
			//Assert.AreEqual (111.405, distance); 
			Assert.That (60.2, Is.GreaterThan(distance));
			//Test 2
			coordinate1 = utility.CalculateCoordinate (10, 1, 5000);
			coordinate2 = utility.CalculateCoordinate (10, 0, 5000);

			distance = utility.Distance (coordinate1, coordinate2);

			//Assert.AreEqual (109.724, distance); 
			Assert.That (59.2, Is.LessThan (distance));
			Assert.That (59.3, Is.GreaterThan (distance));
			//Test 3
			coordinate1 = utility.CalculateCoordinate (70, 1, 5000);
			coordinate2 = utility.CalculateCoordinate (70, 0, 5000);

			distance = utility.Distance (coordinate1, coordinate2);

			//Assert.AreEqual (38.215, distance); //works
			Assert.That (20.6, Is.LessThan (distance));
			Assert.That (20.7, Is.GreaterThan (distance));
		}

		[Test()]
		public void IntersectionTest()
		{
			//Test1
			MathCalcUtility utility = new MathCalcUtility ();


			Vector<double> plane1DataFrom = Vector<double>.Build.DenseOfArray(new double[3]{0, -1, 0});
			Vector<double> plane1DataTo = Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0});

			Vector<double> plane2DataFrom = Vector<double>.Build.DenseOfArray(new double[3]{6, -1, 0});
			Vector<double> plane2DataTo = Vector<double>.Build.DenseOfArray(new double[3]{5, 0, 0});

			Vector<double> plane1vec = utility.CalculateVector (plane1DataFrom, plane1DataTo);
			Vector<double> plane2vec = utility.CalculateVector (plane2DataFrom, plane2DataTo);

			Aircraft aircraft1 = new Aircraft ("1", plane1vec);
			aircraft1.DataBuffer.Add (plane1DataTo);

			Aircraft aircraft2 = new Aircraft ("2", plane2vec);
			aircraft2.DataBuffer.Add (plane2DataTo);

			double time = utility.Intersection (aircraft1, aircraft2, 0);

			Assert.AreEqual (2.0, time);

		}
	}
}

