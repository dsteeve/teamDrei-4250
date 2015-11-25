#define TRACE

using System;
using System.Diagnostics;

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
			UpdateRadarScreen(intruder.Identifier);
			return true;
		}

		//this method probably needs some coordinates of the aircraft
		private Boolean UpdateRadarScreen (String id)
		{
			Trace.WriteLine ("update radar for plane : " + id);
			return true;
		}

		#endregion
	}
}

