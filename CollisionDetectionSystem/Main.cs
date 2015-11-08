using System;

namespace CollisionDetectionSystem
{
	class MainClass
	{
		/**
		 * Test mode happens if a "testdir=directoryname" is given
		 * otherwise it is normal mode
		 */

		public static int Main (string[] args)
		{
			CollisionDetectionSystem system = new CollisionDetectionSystem ();

			try {
				if (args.Length == 0) {
					system.Start();
				} else {
					if (args[0].StartsWith("testdir")) {
						system.Start(getArgValue(args[0]));
					} else {
						System.Console.WriteLine ("Usage: CollisionDetecionSystem testDir=testDirname to run in test mode");
					} 
				}
				return 0;
			} catch (Exception e){
				System.Console.WriteLine ("ooops, sorry, I ended with error:  " + e.GetBaseException ());
				return -1;
			}

		}
	

		/**
		 * split out the name=value
		 * return the value
		 */

		private static String getArgValue(String namevaluepair) {
			String[] values = namevaluepair.Split ('=');
			if (values.Length == 2) {
				return values [1];
			} else {
				return null;
			}
		}
	}
}
