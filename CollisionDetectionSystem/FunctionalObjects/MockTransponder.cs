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
			var dataList = buildTransporterDataList (testDirName);

			while(dataList.Any())
			{
				dataList = sendData (dataList);
			}
		}

		public List<TransponderData> sendData (List<TransponderData>  dataList )  
		{
			var listToSend = new List<TransponderData> ();
			listToSend.Add (dataList [0]);

			for (int i = 1; i<dataList.Count; i++) 
			{
				if((dataList [0].Timestamp).Equals (dataList [i].Timestamp))
				{
					listToSend.Add (dataList[i]);
					dataList.RemoveAt(i);
				}
				else
				{
					break;
				}
			}

			dataList.RemoveAt(0);

			BroadcastDataEvent (listToSend);

			return dataList;
		}

		public List<TransponderData> buildTransporterDataList (String testDirName)  
		{
			var files = streamReaders (testDirName);

			var dataList = new List<TransponderData> ();
			String line = "";
			int count = 1;

			while (files.Any())
			{
				for (int i = 0; i < files.Count; i++) {
					if ((line = (files [i]).ReadLine ()) == null) {
						files.Remove (files [i]);
					} else if (line.StartsWith ("#") || line.Equals ("")) {
						i--;
					} else {
						count++;
						//Console.WriteLine (line + "    " + count / 2); // prints line + the line number, ignores lines with #'s

						string[] splitData = line.Split (',');

						if (splitData.Length == 6) {
							TransponderData tData = new TransponderData (splitData [0], splitData [1], double.Parse (splitData [2]), double.Parse (splitData [3]), double.Parse (splitData [4]), splitData [5]);
							dataList.Add (tData);
						}
					}
				}
			}
			return dataList;
		}
		public List<StreamReader> streamReaders (String testDirName)
		{
			//Console.WriteLine ("testdir=" + testDirName);
			var files = new List<StreamReader> ();

			string[] txtFiles = Directory.GetFiles (testDirName, "*.txt").Select (path => Path.GetFileName (path)).ToArray (); //array of text files                           

			for (int i = 0; i < txtFiles.Length; i++) { //fills list with all streamreaders
				StreamReader file = new StreamReader (testDirName + "\\" + txtFiles.GetValue (i));
				files.Add (file);
			}
			return files;
		}

		//Sends event with transponder data this is the one the
		//transponder receiver is listening to
		void BroadcastDataEvent(List<TransponderData> data) 
		{
			SendDataEvent (data);
		}

		#endregion
	}
}

