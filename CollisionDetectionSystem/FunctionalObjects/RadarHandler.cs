using System;

namespace CollisionDetectionSystem
{
	public class RadarHandler: IRadarHandler
	{
		#region IRadarHandler implementation

		//if intruder is 6 nm in range add to radar screen
		public void AircraftDidEnterRadarRangeEvent (Aircraft intruder)
		{
			//case for updateRadarScreen call
			throw new NotImplementedException ();
		}

		public void UpdateRadarScreen ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

