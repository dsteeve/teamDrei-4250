using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	//are these public once implemented?
	public delegate void TimeDel(float time);
	public delegate void AircraftDel(Aircraft aircraft);

	public interface IDataProcessor
	{
		Aircraft ThisAircraft { get; set; }
		List<Aircraft> Intruders { get; set; }

		void OnPostDataEvent(TransponderData data);
		void UpdateAircraftFromData(TransponderData data);
		void DetermineProximityOfEachIntruder();
		void DetermineProximityOfIntruder(Aircraft intruder);

		event TimeDel AircraftWillIntersectInTimeEvent;
		event AircraftDel AircraftDidEnterRadarRangeEvent;
	}
}

