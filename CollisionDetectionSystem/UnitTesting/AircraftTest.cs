using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class AircraftTest
	{
		[Test ()]
		public void Aircraft ()
		{
			Aircraft ac = new Aircraft ("Fred1", Vector<double>.Build.DenseOfArray(new double[3]{-5, 0, 0}));

			Assert.AreEqual ( "Fred1", ac.Identifier);
			Assert.AreEqual ( -5, ac.Velocity[0]);
			Assert.AreEqual ( 0, ac.Velocity[1]);
			Assert.AreEqual ( 0, ac.Velocity[2]);
		}
	}
}
