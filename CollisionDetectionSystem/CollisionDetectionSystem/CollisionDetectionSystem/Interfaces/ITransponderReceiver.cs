using System;

namespace CollisionDetectionSystem
{
	public delegate void DataDel(TransponderData data);

	public interface ITransponderReceiver
	{
		void RecieveData(TransponderData data);
		void PrepareDataForPost(TransponderData data);
		event DataDel PostData;
	}
}

