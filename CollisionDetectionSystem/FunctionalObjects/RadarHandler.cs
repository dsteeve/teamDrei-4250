#define TRACE

using System;
using System.Diagnostics;

namespace CollisionDetectionSystem
{
	//Radar handling class
	public class RadarHandler: IRadarHandler
	{
		#region IRadarHandler implementation

		//if intruder is 6 nm in range add to radar screen
		public void AircraftDidEnterRadarRangeEvent (Aircraft intruder)
		{
			AircraftDidEnterRadarRangeEventTest (intruder);
		}			

		//method for testing
		public Boolean AircraftDidEnterRadarRangeEventTest (Aircraft intruder)
		{
			UpdateRadarScreen(intruder.Identifier);
			return true;
		}

		//this method probably needs some coordinates of the aircraft
		//currently takes in the string id of the plane.
		private Boolean UpdateRadarScreen (String id)
		{
			Trace.WriteLine ("Update radar for plane : " + id);
			return true;
		}

		#endregion
	}
}

