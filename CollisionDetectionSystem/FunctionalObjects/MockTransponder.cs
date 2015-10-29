using System;

namespace CollisionDetectionSystem
{
	public class MockTransponder: IMockTransponder
	{
		#region IMockTransponder implementation

		public event DataDel ReceiveRadarDataEvent;

		public void Start ()
		{
			throw new NotImplementedException ();
		}

		void BroadcastReceiveDataEvent(TransponderData data){
			ReceiveRadarDataEvent (data);
		}

		#endregion
	}
}

