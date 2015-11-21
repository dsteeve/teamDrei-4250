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
			//TODO:  case for updateRadarScreen call

			UpdateRadarScreen();
			return true;
		}

		//this method probably needs some coordinates of the aircraft
		private Boolean UpdateRadarScreen ()
		{
			Console.WriteLine ("the radar would be updated here.");
			return true;
		}

		#endregion
	}
}

