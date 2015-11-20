using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	public delegate void DataDel( List<TransponderData> data);

	public interface ITransponderReceiver
	{
		void ReceiveData(List<TransponderData> data);
		void PrepareDataForPost( List<TransponderData> data);
		event DataDel PostDataEvent;
	}
}

