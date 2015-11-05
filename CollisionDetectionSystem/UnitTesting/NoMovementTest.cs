using System;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class NoMovementTest
	{
		[Test ()]
		public void NoMovementAtAllTest ()
		{
			IMathCalcUtility mathUtil = new MathCalcUtility ();
			Aircraft tetheredBalloon = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{0, 0, 0}));
			tetheredBalloon.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{0, 0, 0}));

			Aircraft thisAircraft = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));
			thisAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));

			double intersection = mathUtil.Intersection (tetheredBalloon, thisAircraft, 1);

			Assert.AreEqual (-1.0, intersection); //should be no intersection since tetheredBalloon isn't moving

			thisAircraft.Velocity = Vector<double>.Build.DenseOfArray (new double[3]{ 1, 2, 0 });
			intersection = mathUtil.Intersection (tetheredBalloon, thisAircraft, 1);

			Assert.AreEqual (-1.0, intersection); //still no intersection after thisAircraft changed course
		}

		[Test ()]
		public void StopMovementTest ()
		{

			IMathCalcUtility mathUtil = new MathCalcUtility ();
			Aircraft stoppingAircraft = new Aircraft ("1", Vector<double>.Build.DenseOfArray(new double[3]{-5, 0, 0}));
			stoppingAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{50, 0, 0}));

			Aircraft thisAircraft = new Aircraft ("2", Vector<double>.Build.DenseOfArray(new double[3]{1, 0, 0}));
			thisAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{0, 0, 0}));

			double intersection = mathUtil.Intersection (thisAircraft, stoppingAircraft, 1);

			Assert.AreEqual (Math.Sign(1), Math.Sign(intersection)); //On collision course

			stoppingAircraft.Velocity = Vector<double>.Build.DenseOfArray (new double[3]{ 0, 0, 0 });
			// stoppingAircraft has stopped moving completely
			intersection = mathUtil.Intersection (stoppingAircraft, thisAircraft, 1);

			Assert.AreEqual (Math.Sign(1), Math.Sign(intersection)); //Still collision

			thisAircraft.Velocity = Vector<double>.Build.DenseOfArray (new double[3]{ 1, -10, 0 });
			intersection = mathUtil.Intersection (stoppingAircraft, thisAircraft, 1);

			Assert.AreEqual (-1.0, intersection); //No intersection after thisAircraft changed course
		}
	}
}

