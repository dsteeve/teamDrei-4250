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
			CollisionDetectionSystemClass system = new CollisionDetectionSystemClass ();

			try {
				if (args.Length == 0) {
					system.Start();
				} else {
					if (args[0].StartsWith("testdir")) {
						system.Start(StringUtility.getArgValue(args[0]));
					} else {
						if (args[0].StartsWith("testdir")) {
							system.Start(StringUtility.getArgValue(args[0]));
						} else {
							System.Console.WriteLine ("Usage: CollisionDetecionSystem testDir=testDirname to run in test mode");
						} 
					}
				}
				return 0;
			} catch (Exception e){
				System.Console.WriteLine ("ooops, sorry, I ended with error:  " + e.GetBaseException ());
				return -1;
			}

		}
	}
}
