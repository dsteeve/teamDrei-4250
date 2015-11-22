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

		public void ReceiveData (List<TransponderData> data)
		{
			PrepareDataForPost (data);
		}
			
		/**
		 * DataProcessor onPostDataEvent listens to this PostDataEvent
		 * 
		 */
		public void PrepareDataForPost (List<TransponderData> data)
		{
			//Call event, anything attached to this event delegate will be executed
			PostDataEvent (data); 
		}

		#endregion
	}
}

