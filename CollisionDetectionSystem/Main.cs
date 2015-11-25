#define TRACE

using System;
using System.IO;
using System.Diagnostics;

namespace CollisionDetectionSystem
{
	class MainClass
	{
		/**
		 * Test mode happens if a "testdir=directoryname" is given
		 * otherwise it is normal mode 
		 * normal mode means it is on an aircraft getting pings from transponders.
		 */

		public static int Main (string[] args)
		{
			
			Trace.Listeners.Add(new TextWriterTraceListener("./cds.log"));
			Trace.AutoFlush = true;

			CollisionDetectionSystemClass cds = new CollisionDetectionSystemClass ();

			try {
				if (args.Length == 0) {
					cds.Start();
				} else {
					if (args[0].StartsWith("testdir")) {
						cds.Start(StringUtility.getArgValue(args[0]));
					} else {
						if (args[0].StartsWith("testDir")) {
							cds.Start(StringUtility.getArgValue(args[0]));
						} else {
							Console.WriteLine ("Usage: CollisionDetectionSystem testdir=testDirectoryName to run in test mode");
						} 
					}
				}
				Console.WriteLine ("completed successfully");
				return 0;
			} catch (Exception e){
				Console.WriteLine ("ooops, sorry, I ended with error:  " + e.GetBaseException ());
				return -1;
			}
			finally {
				Trace.WriteLine ("completed.");
				Trace.Flush ();
			}

		}
	}
}
