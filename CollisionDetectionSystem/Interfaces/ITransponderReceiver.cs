using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	public delegate void DataDel( TransponderData tdata);

	public interface ITransponderReceiver
	{
		void ReceiveData(TransponderData tdata);
		void PrepareDataForPost( TransponderData tdata);
		event DataDel PostDataEvent;
	}
}

