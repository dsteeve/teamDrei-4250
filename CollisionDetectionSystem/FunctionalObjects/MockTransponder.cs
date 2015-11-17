using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	public class MockTransponder: IMockTransponder
	{
		#region IMockTransponder implementation

		public event DataDel SendDataEvent;

		// will get a directory name to read the files in
		// the files will have a list of fake data to go through 
		// and announce location every 500ms
		public void Start (String testDirName)  
		{
			System.Console.WriteLine ("test dir name is : " + testDirName);
			var files = new List<StreamReader>();

			//throw new NotImplementedException ();  //methods to read in and translate data to build TranponderDatay types

			string[] txtFiles = Directory.GetFiles(testDirName, "*.txt").Select(path => Path.GetFileName(path)).ToArray(); //array of text files                           

			for (int i = 0; i < txtFiles.Length; i++) //fills list with all streamreaders
			{
				StreamReader file = new StreamReader (testDirName + "\\" + txtFiles.GetValue (i));
				files.Add (file);
			}


			String line = "something"; //reading a line of each file at a time... 
			while (!line.Equals(null))
			{
				for (int i = 0; i < files.Count; i++) {
					line = (files [i]).ReadLine ();
					Console.WriteLine (line);
				}
			}
		}

		//Sends event with transponder data this is the one the
		//transponder receiver is listening to
		void BroadcastDataEvent(TransponderData data) 
		{
			SendDataEvent (data);
		}

		#endregion
	}
}

