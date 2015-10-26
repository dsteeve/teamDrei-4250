using System;

namespace CollisionDetectionSystem
{
	public class RadarHandler: IRadarHandler
	{
		#region IRadarHandler implementation

		public void AircraftDidEnterRadarRangeEvent (Aircraft intruder)
		{
			throw new NotImplementedException ();
		}

		public void UpdateRadarScreen ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

