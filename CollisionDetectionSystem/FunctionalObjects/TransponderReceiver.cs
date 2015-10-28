using System;

namespace CollisionDetectionSystem
{
	public class TransponderReciever: ITransponderReceiver
	{
		#region ITransponderReciever implementation

		public event DataDel PostData;

		public void RecieveData (TransponderData data)
		{
			//Do some stuff

			PrepareDataForPost (data);
		}

		public void PrepareDataForPost (TransponderData data)
		{
			//Do some stuff

			PostData (data); //Call event, anything attached to this event delegate will be executed.
		}

		#endregion
	}
}

