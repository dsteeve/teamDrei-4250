using System;

namespace CollisionDetectionSystem
{
	public class RadarHandler: IRadarHandler
	{
		#region IRadarHandler implementation

		//if intruder is 6 nm in range add to radar screen
		public void AircraftDidEnterRadarRangeEvent (Aircraft intruder)
		{
			AircraftDidEnterRadarRangeEventTest (intruder);
		}			

		public Boolean AircraftDidEnterRadarRangeEventTest (Aircraft intruder)
		{
			//case for updateRadarScreen call
			throw new NotImplementedException ();
		}

		private Boolean UpdateRadarScreen ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

