using System;
using NUnit.Framework;
using CollisionDetectionSystem;
using MathNet.Numerics.LinearAlgebra;

namespace UnitTesting
{
	[TestFixture ()]
	public class FasterAircraftTest
	{
		[Test ()]
		public void FasterAircraftInFront()
		{
			IMathCalcUtility mathUtil = new MathCalcUtility ();

			Aircraft fasterAircraft = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{5, 0, 0}));
			fasterAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{5, 0, 0}));

			Aircraft thisAircraft = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));
			thisAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));

			double intersection = mathUtil.Intersection (fasterAircraft, thisAircraft, 1);

			Assert.AreEqual (-1.0, intersection); //should be no intersection
		}

		[Test ()]
		public void FasterAircraftCollision()
		{
			IMathCalcUtility mathUtil = new MathCalcUtility ();

			Aircraft fasterAircraft = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{-5, 0, 0}));
			fasterAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{50, 0, 0}));

			Aircraft thisAircraft = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));
			thisAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{0, 0, 0}));

			double intersection = mathUtil.Intersection (thisAircraft, fasterAircraft, 1);

			Assert.AreEqual (Math.Sign(1), Math.Sign(intersection)); //should be an intersection //
		}
	}
}



