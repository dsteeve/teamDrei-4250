using System;

namespace CollisionDetectionSystem
{
	public class MockTransponder: IMockTransponder
	{
		#region IMockTransponder implementation

		public event DataDel ReceiveRadarDataEvent;

		public void Start ()  // will get an array to go through it every second
		{
			throw new NotImplementedException ();  //methods to read in and translate data to build TranponderDatay types
		}

		//sends event with transponder data this is the one the
		//transponder receiver is listening to
		void BroadcastReceiveDataEvent(TransponderData data) 
		{
			ReceiveRadarDataEvent (data);
		}

		#endregion
	}
}

