using System;

namespace CollisionDetectionSystem
{
	public interface IMockTransponder
	{
		void Start(String testDirName);
		event ListDataDel SendDataEvent;
	}
}

