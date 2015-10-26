using System;

namespace CollisionDetectionSystem
{
	public class MockTransponder: IMockTransponder
	{
		#region IMockTransponder implementation

		public event DataDel RecieveRadarDataEvent;

		public void Start ()
		{
			throw new NotImplementedException ();
		}

		void BroadcastRecieveDataEvent(TransponderData data){
			RecieveRadarDataEvent (data);
		}

		#endregion
	}
}

