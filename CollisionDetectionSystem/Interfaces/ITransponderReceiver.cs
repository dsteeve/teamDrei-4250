using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	public delegate void DataDel( TransponderData tdata);
	public delegate void ListDataDel ( List<TransponderData> dataList);

	public interface ITransponderReceiver
	{
		void ReceiveData(List<TransponderData> data);
		void PrepareDataForPost( List<TransponderData> data);
		event ListDataDel PostDataEvent;
	}
}

