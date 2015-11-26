#define TRACE

using System;
using System.Diagnostics;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class DataProcessor : IDataProcessor
	{
		//OUR ICAO CODE B1E24F
		public Aircraft ThisAircraft { get; set; }
		public List<Aircraft> Intruders { get; set; }
		private MathCalcUtility MathUtility { get; set; }

		public DataProcessor ()
		{
			Intruders = new List<Aircraft> ();
			ThisAircraft = new Aircraft ("B1E24F", Vector<double>.Build.Dense(3)); //Vector in R^3
			MathUtility = new MathCalcUtility();
		}

		#region IDataProcessor implementation

		public event TimeDel AircraftWillIntersectInTimeEvent;
		public event AircraftDel AircraftDidEnterRadarRangeEvent;

		public void OnPostDataEvent (List<TransponderData> data) 
		{
			//Update all intruders and self
			//The list will always contain ourself at least.
			foreach (var tdata in data) {
				Update (tdata);
			}

			RemoveOutOfRangeIntruders ();

			//Then we check if any of the intruders are now in proximity
			if (Intruders != null && Intruders.Count > 0 && ThisAircraft.Velocity != null) {
				DetermineProximityOfIntruders ();
			}
		}

		private void Update(TransponderData tdata){
			
			if (tdata.Icao == ThisAircraft.Identifier) {
				UpdateAircraftFromData(tdata, ThisAircraft);
			} else {
				bool found = false;

				foreach (var intruder in Intruders) {
					if (intruder.Identifier == tdata.Icao) {
						UpdateAircraftFromData (tdata, intruder);
						found = true;
					}
				}

				if (!found) {
					AddNewIntruder (tdata);
				}
			}

		}

		private void AddNewIntruder(TransponderData data)
		{
			if(WithinRadarRange(data)){
				Aircraft newIntruder = new Aircraft (data.Icao);
				Intruders.Add (newIntruder);
				UpdateAircraftFromData (data, newIntruder);
			}
		}

		private bool WithinRadarRange(TransponderData data){
			if (ThisAircraft.DataBuffer.Count > 0) {
				var intruderCoordinate = MathUtility.CalculateCoordinate (data.Latitude, data.Longitude, data.Altitude);
				var distance = MathUtility.Distance (intruderCoordinate, ThisAircraft.DataBuffer [0]);

				//if distance is less than 6 NM return true
				if (distance < 6.0) {
					return true;
				}
			}

			return false;
		}

		private bool WithinRadarRange(Aircraft aircraft){
			if (ThisAircraft.DataBuffer.Count > 0) {
				var distance = MathUtility.Distance (aircraft.DataBuffer[0], ThisAircraft.DataBuffer [0]);

				//if distance is less than 6 NM return true
				Trace.WriteLine("Distance to aircraft " + aircraft.Identifier + ": " + distance);
				if (distance < 6.1) {
					return true;
				}
			}

			return false;
		}

		private void RemoveOutOfRangeIntruders()
		{
			if(ThisAircraft.DataBuffer.Count > 0){
				foreach (var intruder in Intruders) {
					if (intruder.DataBuffer.Count > 0) {
						var distance = MathUtility.Distance (intruder.DataBuffer [0], ThisAircraft.DataBuffer [0]);

						//Remove if greater than 20 Nautical Miles
						if (distance > 20) {
							Intruders.Remove (intruder);
						}

						//Remove if greater than 6 Nautical Miles (in km)
						//if (distance > 11.112) {
						//	Intruders.Remove (intruder);
						//}
					}
				}
			}
		}
			
		// convert to cordinates 
		// look for air craft and list and update if in list, else create new
		private void UpdateAircraftFromData (TransponderData data, Aircraft aircraft)
		{
			var coordinate = MathUtility.CalculateCoordinate (data.Latitude, data.Longitude, data.Altitude);
			aircraft.DataBuffer.Insert (0, coordinate);

			if (aircraft.DataBuffer.Count > 1) {
				aircraft.Velocity = MathUtility.CalculateVector (aircraft.DataBuffer [1], aircraft.DataBuffer [0]);
			}

			//remove the last data entry
			if (aircraft.DataBuffer.Count > 20) {
				aircraft.DataBuffer.RemoveAt (aircraft.DataBuffer.Count - 1);
			}

//			if (aircraft != ThisAircraft && aircraft.Velocity != null) {
//				Console.WriteLine("our aircraft: " + ThisAircraft );
//				Console.WriteLine("intruder aircraft" + aircraft);
//				DetermineProximityOfIntruder (aircraft);
//			}
		}

		private void DetermineProximityOfIntruders () {
			foreach (var intruder in Intruders) {
				if (intruder.Velocity != null) {
					Trace.WriteLine("our aircraft: " + ThisAircraft );
					Trace.WriteLine("intruder aircraft" + intruder);
					DetermineProximityOfIntruder (intruder);
				}
			}
		}

		//MathCalcUtility to determine proximity of our aircraft to another
		private void DetermineProximityOfIntruder (Aircraft intruder)
		{
			

			//If in proximity...
			//Calculate time...
			var timeUntilIntersection = MathUtility.Intersection (ThisAircraft, intruder, 0.0822894); //radius of 500 feet (in NM)

			Trace.WriteLine ("time until intersection: " + timeUntilIntersection);

			if (timeUntilIntersection > 0) {
				//this is a refactored method defined below
				CheckAltitudeDifference (intruder, timeUntilIntersection);                
			} 
			/*otherwise time until intersection is negative (actually -1) and we overlapped
			here we want to continue to give instructions to the pilot until the distance
			between the planes begins to increase, I think that once we exit the critical range
			of .0822894 nm we will no longer report from here*/
			else {
				if ((MathUtility.Distance(ThisAircraft.DataBuffer[1],intruder.DataBuffer[1]) > 
					MathUtility.Distance(ThisAircraft.DataBuffer[0],intruder.DataBuffer[0]))
					&& (MathUtility.Distance(ThisAircraft.DataBuffer[0],intruder.DataBuffer[0])
						< .0822894))
					CheckAltitudeDifference (intruder, timeUntilIntersection);
			}
				
			//If in radar range...
			if(WithinRadarRange(intruder)){
				AircraftDidEnterRadarRangeEvent(intruder);
			}
		}
		//refactored this method out of DetermineProximityOfIntruder because we will call for different reasons
		private void CheckAltitudeDifference (Aircraft intruder, double timeUntilIntersection){
			if (intruder.DataBuffer [0].L2Norm () > ThisAircraft.DataBuffer [0].L2Norm ()) {
				AircraftWillIntersectInTimeEvent (timeUntilIntersection, Position.Above);
			} else {
				AircraftWillIntersectInTimeEvent (timeUntilIntersection, Position.Below);
			}
		}

		#endregion
	}
}

