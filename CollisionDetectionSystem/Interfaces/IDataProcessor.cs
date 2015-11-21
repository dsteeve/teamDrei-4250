using System;
using System.Collections.Generic;

namespace CollisionDetectionSystem
{
	//are these public once implemented?
	public delegate void TimeDel(double time, Position position);
	public delegate void AircraftDel(Aircraft aircraft);

	public interface IDataProcessor
	{
		Aircraft ThisAircraft { get; set; }
		List<Aircraft> Intruders { get; set; }

		void OnPostDataEvent( List<TransponderData> data);

		event TimeDel AircraftWillIntersectInTimeEvent;
		event AircraftDel AircraftDidEnterRadarRangeEvent;
	}
}

