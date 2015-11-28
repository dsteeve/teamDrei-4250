#define TRACE

using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;
using System.Collections.Generic;

/**
 * Mimics the behavior of various transponders on various aircrafts 
 * responding to a ping
 * 
 */

namespace CollisionDetectionSystem
{
	public class MockTransponder: IMockTransponder
	{
		#region IMockTransponder implementation

	public event ListDataDel SendDataEvent;

		/** 
		 * Takes a directory name to read the system test files in
		 * The files will have a list of fake data to go through 
		 * and announce location every 500ms
		 */
		public void Start (String testDirName)  
		{
			var dataList = buildTransporterDataList (testDirName);

			while(dataList.Any())
			{
				dataList = sendData (dataList);
			}
		}

		/**
		 * correlates the data based on timestamps
		 * handling just 2 lists right now.
		 * TODO: eventually we would want to handle all the lists in the directory
		 */

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
			System.Threading.Thread.Sleep (200);

			return dataList;
		}

		/**
		 * Given the name of the directory
		 * Build a list of TransponderData from the test files in that directory
		 */

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
						printComment (line);
						i--;
					} else {
						count++;
						//Console.WriteLine (line + "    " + count / 2); // prints line + the line number, ignores lines with #'s

						string[] splitData = line.Split (',');

						if (splitData.Length == 6) {
							TransponderData tData = new TransponderData (splitData [0], splitData [1], 
								double.Parse (splitData [2]), double.Parse (splitData [3]), 
								double.Parse (splitData [4]), splitData [5]);
							dataList.Add (tData);
						}
					}
				}
			}
			return dataList;
		}

		public void printComment (String commentLine) {
			if (commentLine.StartsWith("#") ){
				Trace.WriteLine(commentLine);
			}
		}

		/**
		 *
		 */
		public List<StreamReader> streamReaders (String testDirName)
		{
			
			var files = new List<StreamReader> ();

			string[] txtFiles = Directory.GetFiles (testDirName, "*.txt").Select (path => Path.GetFileName (path)).ToArray (); //array of text files   

			for (int i = 0; i < txtFiles.Length; i++) { //fills list with all streamreaders
				StreamReader file = new StreamReader (testDirName + Path.DirectorySeparatorChar + txtFiles.GetValue (i));
				files.Add (file);
			}
			return files;
		}

		/** 
		 * Sends event with transponder data this is the one the
		 *  transponderReceiver.receiveData() is wired up to listen to.
		 * 
		 * Here we are simulating transponder data responses from various aircraft (including our own aircraft)
		 * sending us data nearly the same time.
		 */
		void BroadcastDataEvent(List<TransponderData> data) 
		{
			Trace.WriteLine ("Mocking data list size is :" + data.Count);

			for (int i = 0; i< data.Count; i++ ) {
				Trace.WriteLine ("sending mocked data: " + data [i]);
				//SendDataEvent (data[i]);
			}
			SendDataEvent (data);
		}

		#endregion
	}
}

