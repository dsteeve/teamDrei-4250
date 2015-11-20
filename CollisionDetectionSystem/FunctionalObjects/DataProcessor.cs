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

		//calls update aircraft
		//to be decided 
		public void OnPostDataEvent ( List<TransponderData> data) 
		{
			//update ourselves or another aircraft

			// this will likely NEED a for loop to go through the data events in the data list, i made it to 0 so it'll work for now but this is what needs to
			// be changed more than likely.

			if (data[0].Icao == ThisAircraft.Identifier) {
				UpdateAircraftFromData(data[0], ThisAircraft);
			} else {
				bool found = false;

				foreach (var intruder in Intruders) {
					if (intruder.Identifier == data[0].Icao) {
						UpdateAircraftFromData (data[0], intruder);
						found = true;
					}
				}

				if (!found) {
					AddNewIntruder (data[0]);
				}
			}

			RemoveOutOfRangeIntruders ();
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
//				if (distance < 6.0) {
//					return true;
//				}

				//if distance is less than 6 NM return true (in km)
				if (distance < 11.112) {
					return true;
				}
			}

			return false;
		}

		private bool WithinRadarRange(Aircraft aircraft){
			if (ThisAircraft.DataBuffer.Count > 0) {
				var distance = MathUtility.Distance (aircraft.DataBuffer[0], ThisAircraft.DataBuffer [0]);

				//if distance is less than 6 NM return true
				//				if (distance < 6.0) {
				//					return true;
				//				}

				//if distance is less than 6 NM return true (in km)
				if (distance < 11.112) {
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

//						//Remove if greater than 6 Nautical Miles
//						if (distance > 6.0) {
//							Intruders.Remove (intruder);
//						}

						//Remove if greater than 6 Nautical Miles (in km)
						if (distance > 11.112) {
							Intruders.Remove (intruder);
						}
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

			if (aircraft != ThisAircraft && aircraft.Velocity != null) {
				DetermineProximityOfIntruder (aircraft);
			}
		}

		//MathCalcUtility to determine proximity of our aircraft to another
		private void DetermineProximityOfIntruder (Aircraft intruder)
		{

			//If in proximity...
			//Calculate time...
			var timeUntilIntersection = MathUtility.Intersection (ThisAircraft, intruder, 1);
			if (timeUntilIntersection > 0) {
				
				if (intruder.DataBuffer [0] [2] > ThisAircraft.DataBuffer [0] [2]) {
					AircraftWillIntersectInTimeEvent (timeUntilIntersection, Position.Above);
				} else {
					AircraftWillIntersectInTimeEvent (timeUntilIntersection, Position.Below);
				}
			}

			//If in radar range...
			if(WithinRadarRange(intruder)){
				AircraftDidEnterRadarRangeEvent(intruder);
			}
				
		}

		#endregion
	}
}

