using NUnit.Framework;
using System;
using CollisionDetectionSystem;
using MathNet.Numerics.LinearAlgebra;

namespace UnitTesting
{
	[TestFixture ()]
	public class MathTest
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
//
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

			Assert.AreEqual (-2516.715, result[0]);
			Assert.AreEqual (-4653.003, result[1]);
			Assert.AreEqual (3551.245, result[2]);

			Vector<double> result2 = utility.CalculateCoordinate (100, 100, 100);

			Assert.AreEqual (192.955, result2 [0]);
			Assert.AreEqual (-1094.301, result2 [1]);
			Assert.AreEqual (6259.641, result2 [2]);

		}

		[Test()]
		public void DistanceTest(){

			//Test 1
			MathCalcUtility utility = new MathCalcUtility ();
			Vector<double> coordinate1 = utility.CalculateCoordinate (0, 1, 5000);
			Vector<double> coordinate2 = utility.CalculateCoordinate (0, 0, 5000);

			double distance = utility.Distance (coordinate1, coordinate2);

			Assert.AreEqual (111.405, distance);

			//Test 2
			coordinate1 = utility.CalculateCoordinate (10, 1, 5000);
			coordinate2 = utility.CalculateCoordinate (10, 0, 5000);

			distance = utility.Distance (coordinate1, coordinate2);

			Assert.AreEqual (109.274, distance);

			//Test 3
			coordinate1 = utility.CalculateCoordinate (70, 1, 5000);
			coordinate2 = utility.CalculateCoordinate (70, 0, 5000);

			distance = utility.Distance (coordinate1, coordinate2);

			Assert.AreEqual (38.215, distance);

		}

		[Test()]
		public void IntersectionTest()
		{
			//Test1
//			MathCalcUtility utility = new MathCalcUtility ();
//
//			TransponderData plane1DataFrom = new TransponderData (1, 2, 0, "1");
//			TransponderData plane1DataTo = new TransponderData (2, 3, 0, "1");
//
//			TransponderData plane2DataFrom = new TransponderData (5, 2, 0, "2");
//			TransponderData plane2DataTo = new TransponderData (4, 3, 0, "2");
//
//			Vector<double> plane1vec = utility.CalculateVector (plane1DataFrom, plane1DataTo);
//			Vector<double> plane2vec = utility.CalculateVector (plane2DataFrom, plane2DataTo);
//
//			Aircraft aircraft1 = new Aircraft ("1", plane1vec);
//			aircraft1.DataBuffer.Add (plane1DataTo);
//
//			Aircraft aircraft2 = new Aircraft ("2", plane2vec);
//			aircraft2.DataBuffer.Add (plane2DataTo);
//
//			double time = utility.Intersection (aircraft1, aircraft2, 1f);
//
//			Assert.AreEqual (1.0, time);
//
//			//Test2
//			plane1DataFrom = new TransponderData (1, 2, 0, "1");
//			plane1DataTo = new TransponderData (2, 3, 0, "1");
//
//			plane2DataFrom = new TransponderData (7, 2, 0, "2");
//			plane2DataTo = new TransponderData (6, 3, 0, "2");
//
//			plane1vec = utility.CalculateVector (plane1DataFrom, plane1DataTo);
//			plane2vec = utility.CalculateVector (plane2DataFrom, plane2DataTo);
//
//			aircraft1 = new Aircraft ("1", plane1vec);
//			aircraft1.DataBuffer.Add (plane1DataTo);
//
//			aircraft2 = new Aircraft ("2", plane2vec);
//			aircraft2.DataBuffer.Add (plane2DataTo);
//
//			time = utility.Intersection (aircraft1, aircraft2, 1f);
//
//			Assert.AreEqual (2.0, time);
		}
	}
}

