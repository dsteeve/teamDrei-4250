using System;
using System.Collections.Generic;
using System.Timers;

namespace CollisionDetectionSystem
{
	/**
	 * TransponderReceiver receives the transponder data
	 * from various aircrafts in the vicinity.  In testMode, 
	 * pings from various aircrafts are mocked via the MockTransponder,
	 * and data read in from test files.
	 */

	public class TransponderReceiver: ITransponderReceiver
	{
		#region ITransponderReceiver implementation

		public event ListDataDel PostDataEvent;

		//Stack<TransponderData> tdataStack = new Stack<TransponderData> ();

//		public void ReceiveData (TransponderData data)
//		{
//			//check valid data and drop it if invalid 
//
//			//stack of data
//			//tdataStack.Push(data);
//
//			//probably want to process the stack in a new thread.
//			// we will process the data in the stack
//			//last in first out, since the most recent data is the most relevant to us
//			//processStack();
//		}


		//		public void processStack() {
		//			//should be in a while loop
		//			if (tdataStack.Count > 0) {
		//				PrepareDataForPost (tdataStack.Pop ());
		//			}
		//		}

		public void StartTimer(){
			DataList = new List<TransponderData> ();
			Timer myTimer = new Timer();
			myTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
			myTimer.Interval = 500; // 500 ms is a half second
			myTimer.Start();
		}

		public void TimeEvent(object source, ElapsedEventArgs e)
		{
			if (DataList.Count > 0) {
				PrepareDataForPost (DataList);
				DataList = new List<TransponderData> (); //clear the list
			}
		}

		List<TransponderData> DataList;

		public void ReceiveData (TransponderData data)
		{

			//Remove if we recieved newer data with in the 0.5 seconds
			//and then we just replace it with the newer data.
			//This may or may not be the best way to do this.
			//If you guys have a better way by all means do it.
			foreach (var d in DataList) {
				if (d.Icao == data.Icao) {
					DataList.Remove (d);
				}
			}
		
			DataList.Add(data);
		}


		/**
		 * DataProcessor onPostDataEvent listens to this PostDataEvent
		 * 
		 */
		public void PrepareDataForPost ( List<TransponderData> data)
		{
			//Call event, anything attached to this event delegate will be executed
			PostDataEvent (data); 
		}

		#endregion
	}
}

