using System;

namespace CollisionDetectionSystem
{
	public interface IRadarHandler
	{
		void AircraftDidEnterRadarRangeEvent(Aircraft intruder);
		Boolean AircraftDidEnterRadarRangeEventTest (Aircraft intruder);
	}
}

