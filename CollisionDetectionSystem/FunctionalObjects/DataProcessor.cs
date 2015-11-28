#define TRACE

using System;
using System.Diagnostics;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	/**
	 * Where all the processing occurs for transponder data and aircrafts.
	 */
	public class DataProcessor : IDataProcessor
	{
		public static readonly double RADAR_RANGE_NM = 6.1;
		public static readonly double RADAR_MAX_RANGE_NM = 20.0;
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

		/**
		 * Entry point for receiving Transponder data
		 */
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

		/**
		 * Update given aircraft with latest transponder data
		 */
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

		/**
		 * Add a new intruder to the list
		 */
		private void AddNewIntruder(TransponderData data)
		{
			if(WithinRadarRange(data)){
				Aircraft newIntruder = new Aircraft (data.Icao);
				Intruders.Add (newIntruder);
				UpdateAircraftFromData (data, newIntruder);
			}
		}
			
		/**
		 * Determine if given Transponder data is within radar range
		 * 
		 * return true if it is, else false.
		 */
		private bool WithinRadarRange(TransponderData data){
			if (ThisAircraft.DataBuffer.Count > 0) {
				var intruderCoordinate = MathUtility.CalculateCoordinate (data.Latitude, data.Longitude, data.Altitude);
				var distance = MathUtility.Distance (intruderCoordinate, ThisAircraft.DataBuffer [0]);

				//if distance is less than 6.1 NM return true
				if (distance < RADAR_RANGE_NM) {
					return true;
				}
			}

			return false;
		}

		/**
		 * Determine if given aircraft is within radar range
		 * return true if it is, else false.
		 */
		private bool WithinRadarRange(Aircraft aircraft){
			if (ThisAircraft.DataBuffer.Count > 0) {
				var distance = MathUtility.Distance (aircraft.DataBuffer[0], ThisAircraft.DataBuffer [0]);

				//if distance is less than 6.1 NM return true
				Trace.WriteLine("Distance to aircraft " + aircraft.Identifier + ": " + distance);
				if (distance < RADAR_RANGE_NM) {
					return true;
				}
			}

			return false;
		}

		/**
		 * Remove out of Range Intruders
		 * out of range is defined as more than 20 nm's
		 *
		 */
		private void RemoveOutOfRangeIntruders()
		{
			if(ThisAircraft.DataBuffer.Count > 0){
				foreach (var intruder in Intruders) {
					if (intruder.DataBuffer.Count > 0) {
						var distance = MathUtility.Distance (intruder.DataBuffer [0], ThisAircraft.DataBuffer [0]);

						//Remove if greater than 20 Nautical Miles
						if (distance > RADAR_MAX_RANGE_NM) {
							Intruders.Remove (intruder);
						}
					}
				}
			}
		}

		/**
		 * Update Aircrafts with newest data
		 */
		private void UpdateAircraftFromData (TransponderData data, Aircraft aircraft)
		{
			// convert tdata to cordinates 
			var coordinate = MathUtility.CalculateCoordinate (data.Latitude, data.Longitude, data.Altitude);
			aircraft.DataBuffer.Insert (0, coordinate);

			//calc velocity
			if (aircraft.DataBuffer.Count > 1) {
				aircraft.Velocity = MathUtility.CalculateVector (aircraft.DataBuffer [1], aircraft.DataBuffer [0]);
			}

			//remove the last data entry (clean up old data)
			if (aircraft.DataBuffer.Count > 20) {
				aircraft.DataBuffer.RemoveAt (aircraft.DataBuffer.Count - 1);
			}
				
		}
		/**
		 * Determine Proximity of Intruders
		 */
		private void DetermineProximityOfIntruders () {
			foreach (var intruder in Intruders) {
				if (intruder.Velocity != null) {
					Trace.WriteLine("our aircraft: " + ThisAircraft );
					Trace.WriteLine("intruder aircraft" + intruder);
					DetermineProximityOfIntruder (intruder);
				}
			}
		}

		/**
		 * Determine Proximity of given Intruder aircraft
		 *
		 */
		private void DetermineProximityOfIntruder (Aircraft intruder)
		{
			
			//Calculate time until intersection
			var timeUntilIntersection = MathUtility.Intersection (ThisAircraft, intruder, 0.0822894); //radius of 500 feet (in NM)

			Trace.WriteLine ("time until intersection: " + timeUntilIntersection);

			//if > 0, then we are on trajectory to intersect.
			if (timeUntilIntersection > 0) {
				CheckAltitudeDifference (intruder, timeUntilIntersection);                
			} 
			/* otherwise time until intersection is negative (actually -1) and we overlapped.
			   Here we want to continue to give instructions to the pilot until the distance
			   between the planes begins to increase.
			   Once we exit the critical range of .0822894 nm (taking into account our sphere bubble)
			   we will no longer report from here
			*/
			else {
				if (ThisAircraft.DataBuffer.Count > 1 && intruder.DataBuffer.Count > 1) {
					if ((MathUtility.Distance (ThisAircraft.DataBuffer [1], intruder.DataBuffer [1]) >
					    MathUtility.Distance (ThisAircraft.DataBuffer [0], intruder.DataBuffer [0]))
					    && (MathUtility.Distance (ThisAircraft.DataBuffer [0], intruder.DataBuffer [0])
					    < .0822894)) {
						CheckAltitudeDifference (intruder, timeUntilIntersection);
					}
				}
			}
				
			//If in radar range...
			if(WithinRadarRange(intruder)){
				AircraftDidEnterRadarRangeEvent(intruder);
			}
		}

		/**
		 * Check Altitude Difference between aircrafts
		 * to determine instruction to give
		 */
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

