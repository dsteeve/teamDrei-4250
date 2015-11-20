using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	public class TransponderReceiver: ITransponderReceiver
	{
		#region ITransponderReceiver implementation

		public event DataDel PostDataEvent;

		public void ReceiveData ( List<TransponderData> data)
		{
			//check valid data and drop it if invalid 

			PrepareDataForPost (data);
		}

		public void PrepareDataForPost ( List<TransponderData> data)
		{
			//Do some stuff

			PostDataEvent (data); //Call event, anything attached to this event delegate will be executed.
		}

		#endregion
	}
}

