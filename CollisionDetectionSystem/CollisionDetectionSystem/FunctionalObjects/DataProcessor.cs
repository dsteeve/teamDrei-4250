using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class DataProcessor : IDataProcessor
	{
		public Aircraft ThisAircraft { get; set; }
		public List<Aircraft> Intruders { get; set; }

		public DataProcessor ()
		{
			Intruders = new List<Aircraft> ();
			ThisAircraft = new Aircraft ("1", Vector<double>.Build.Dense(3)); //Vector in R^3
		}

		#region IDataProcessor implementation

		public event TimeDel AircraftWillIntersectInTimeEvent;

		public event AircraftDel AircraftDidEnterRadarRangeEvent;

		public void OnPostDataEvent (TransponderData data)
		{
			throw new NotImplementedException ();
		}

		public void UpdateAircraftFromData (TransponderData data)
		{
			throw new NotImplementedException ();
		}

		public void DetermineProximityOfEachIntruder ()
		{
			throw new NotImplementedException ();
		}

		public void DetermineProximityOfIntruder (Aircraft intruder)
		{
			//If in proximity...
			//Calculate time...
			AircraftWillIntersectInTimeEvent(0f); //Some time

			//If in radar range...
			AircraftDidEnterRadarRangeEvent(intruder);
		}

		#endregion
	}
}

