using System;

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
			throw new NotImplementedException ();  //methods to read in and translate data to build TranponderDatay types
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

