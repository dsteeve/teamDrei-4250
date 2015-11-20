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
		 * 	This basically replaces the mainTest.cs class sel remove it, later on this is what we can use to test the different directories
		 *  you can run this atm and it will give what running with directory of ~\SystemTesting\TestData\SystemTests\TestFiles\1
		 */ 

		[Test ()]
		public void startTest ()
		{
			CollisionDetectionSystemClass cds = new CollisionDetectionSystemClass ();
			String path = System.IO.Directory.GetCurrentDirectory ();

			path = path.Split (new String[]{ "UnitTesting\\" }, StringSplitOptions.None) [0] +
				"SystemTesting\\TestData\\SystemTests\\TestFiles\\1";
			String argument = "testdir=" + path;

			cds.Start (StringUtility.getArgValue(argument));

			Assert.True(true);
		}

	}
}
