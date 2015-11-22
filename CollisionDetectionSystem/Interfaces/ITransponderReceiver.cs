using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	public delegate void DataDel( TransponderData tdata);
	public delegate void ListDataDel ( List<TransponderData> dataList);

	public interface ITransponderReceiver
	{
		void ReceiveData(TransponderData tdata);
		void PrepareDataForPost( List<TransponderData> data);
		void StartTimer();
		event ListDataDel PostDataEvent;
	}
}

