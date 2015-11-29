using System;
using System.IO;

namespace UnitTesting
{
	/** 
	 * Helper class for test harness 
	 */
	public static class TestHelper
	{
		public static String buildTestDir() {
			return buildTestDir ("testReadFile");  //default system test if none given
		}


		/**
		 * Builds out the system directory path for given test name
		 * 
		 */
		public static String buildTestDir(String systemTestName){

			String path = System.IO.Directory.GetCurrentDirectory ();
			String [] pieces = path.Split (new String[]{ "UnitTesting"  }, StringSplitOptions.None);
			path = pieces[0] + 
				"SystemTesting" +  Path.DirectorySeparatorChar 
				+ "TestData" +   Path.DirectorySeparatorChar
				+ "SystemTests" +  Path.DirectorySeparatorChar + 
				"TestFiles" +  Path.DirectorySeparatorChar + systemTestName;
			Console.WriteLine ("path: " + path);
			return path;
		}
	}
}

