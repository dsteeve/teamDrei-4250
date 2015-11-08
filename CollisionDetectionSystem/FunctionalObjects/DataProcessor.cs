using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class DataProcessor : IDataProcessor
	{
		//OUR ICAO CODE B1E24F
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

		//calls update aircraft
		//to be decided 
		public void OnPostDataEvent (TransponderData data) 
		{
			//case statement to update ourselves or another aircraft
			//UpdateAircraftFromData (data);
			throw new NotImplementedException ();
		}

		// convert to cordinates 
		// look for air craft and list and update if in list, else create new
		public void UpdateAircraftFromData (TransponderData data)
		{
			//DetermineProximityOfEachIntruder(aircraft)
			throw new NotImplementedException ();
		}

		//MathCalcUtility to determine proximity of intruder when we update ourselves
		public void DetermineProximityOfEachIntruder ()
		{
			//walks through the list and calls DetermineProximityOfIntruder
			throw new NotImplementedException ();
		}

		//MathCalcUtility to determine proximity of our aircraft to another
		public void DetermineProximityOfIntruder (Aircraft intruder)
		{
			//If in proximity...
			//Calculate time...
			AircraftWillIntersectInTimeEvent(0f); //Some time
			//log proximity


			//If in radar range...
			AircraftDidEnterRadarRangeEvent(intruder);
		}

		#endregion
	}
}

