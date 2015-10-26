using System;

namespace CollisionDetectionSystem
{
	public interface IRadarHandler
	{
		void AircraftDidEnterRadarRangeEvent(Aircraft intruder);
		void UpdateRadarScreen();
	}
}

