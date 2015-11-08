using System;
using System.Diagnostics;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;




namespace mainTest
{
	[TestFixture ()]
	public class mainTester
	{
		[Test ()]
		public void mainTesterMethod ()
		{
			String path = System.IO.Directory.GetCurrentDirectory ();

			path = path.Split (new String[]{ "UnitTesting\\" }, StringSplitOptions.None) [0] +
				"SystemTesting\\TestData\\SystemTests\\TestFiles\\1";
			String argument = "testdir=" + path;
			Console.WriteLine (argument);
			/*
			 * 	To run with this argument and test the main I coppied this print out then clicked 
			 * 
			 * Run
			 * Run With > Custom Parameters...
			 * and pasted the string into the argument, it did exactly what is programmed to do atm then pops
			 * up the non-implementation errors
			 * 
			 * 
			 * Tried the whole process thing to try and run an exe file with the arugments but couldnt get it to work.
			 * 
			 * to run this form command you can go to 
			 * 
			 * \CollisionDetectionSystem\bin\Debug 
			 * 
			 * you can do something like 
			 *	 CollisionDetectionSystem.exe testdir=D:\Dropbox\4250Project\teamDrei-4250\CollisionDetectionSystem\SystemTesting\TestData\SystemTests\TestFiles\1
			 *	
			 *	and it will do the same thing as through xamarin.
			 *
			 *
			 *
			 * I made a simple bashfile that will do the command line part and print the results, you can do it fromt he git bash
			 * 
			 * the command to run the bash file is
			 * 
			 * ./trial.sh
			 * 
			 * we can add more directories later and make it automated to see what the ouput for each is.
			 */ 

		}
	}
}
