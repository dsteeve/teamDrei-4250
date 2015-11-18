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
			while (files.Any())
			{
				for (int i = 0; i < files.Count; i++) {
					line = (files [i]).ReadLine ();
					if ((line = (files[i]).ReadLine ()) == null) {
						files.Remove (files [i]);
					} else 
					{
						Console.WriteLine (line);

						string[] splitData = line.Split (',');
						//ignore lines that do not have 6 elements (i.e. bad data)
						//would be a good idea to check the individual elements with more care, i.e. try to parse a double and ignore the line or check the ammount of characters in the timestamp...
						if (splitData.Length != 6) {
							continue;
						}
						else
						{
							//set the transponder data then add to the list
							TransponderData tData = new TransponderData (splitData [0], splitData [1], double.Parse(splitData [2]), double.Parse(splitData [3]), double.Parse(splitData [4]), splitData [5]);
							BroadcastDataEvent (tData);
							System.Threading.Thread.Sleep(500);
						}
					}	
				}
			}
		}

		//Sends event with transponder data this is the one the
		//transponder receiver is listening to
		void BroadcastDataEvent(TransponderData data) 
		{
			Console.WriteLine(data.Altitude +" "+data.Latitude+" "+data.Longitude+" "+data.Icao);
			SendDataEvent (data);
		}

		#endregion
	}
}

