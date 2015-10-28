using System;

namespace CollisionDetectionSystem
{
	public delegate void TimeDel(float time);
	public delegate void AircraftDel(Aircraft aircraft);

	public interface IDataProcessor
	{
		void OnPostDataEvent(TransponderData data);
		void UpdateAircraftFromData(TransponderData data);
		void DetermineProximityOfEachIntruder();
		void DetermineProximityOfIntruder(Aircraft intruder);
		event TimeDel AircraftWillIntersectInTimeEvent;
		event AircraftDel AircraftDidEnterRadarRangeEvent;
	}
}

