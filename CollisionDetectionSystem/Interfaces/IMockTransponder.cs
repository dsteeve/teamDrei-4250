using System;

namespace CollisionDetectionSystem
{
	public interface IMockTransponder
	{
		void Start();
		event DataDel ReceiveRadarDataEvent;
	}
}

