using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class CollisionDetectionSystemTest
	{
		/*
		 * 	This basically replaces the mainTest.cs class.
		 *   Later on this is what we can use to test the different system tests
		 *   Right now it runs and it will give what running with directory of ~\SystemTesting\TestData\SystemTests\TestFiles\3
		 */ 

		[Test ()]
		public void startTest ()
		{
			CollisionDetectionSystemClass cds = new CollisionDetectionSystemClass ();
			String systemTestPath = TestHelper.buildTestDir ("3");

			cds.Start (StringUtility.getArgValue(systemTestPath));

			/*
			* TODO: eventually we should be able to check for # of radar and audio events thrown # match that back to what is expected.
			*/
			//I know, this test will not fail, but if the above test fails with catastrophic system error, test will fail

			Assert.True(true); 
		}

	}
}
