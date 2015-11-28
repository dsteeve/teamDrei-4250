using System;
using System.Text.RegularExpressions;

/**
 * Represents the layout of the transponder data
 */

namespace CollisionDetectionSystem
{
	public class TransponderData
	{
		public Nullable<DateTime> PingTimestamp {  get; private set; }
		public String Timestamp {  get; private set; }
		public string Icao {  get; private set; }
		public double Latitude {  get; private set; }
		public double Longitude {  get; private set; }
		public double Altitude {  get; private set; }
		public string SquawkCode {  get; private set; }

		/** 
		 * constructor
		 */
		public TransponderData (string pingTimestamp, string icao, double latitude, double longitude, double altitude, string squawkCode)
		{
			Regex pattern = new Regex ("[ZT ]");
			setPingTimestamp(pattern.Replace(pingTimestamp,""));
			Timestamp = pingTimestamp;
			Icao = icao;
			Latitude = latitude;
			Longitude = longitude;
			Altitude = altitude;
			SquawkCode = squawkCode; //flight number for non-ga flights.

		}
		/**
		 * Given string representation of timestamp
		 * make a DateTime object
		 * Set to null if parse fails.
		 */
		private void setPingTimestamp (String strTimestamp){
			try {
				PingTimestamp = DateTime.Parse(strTimestamp);
			} catch (Exception e) {
				Console.WriteLine ("Unable to parse timestamp: " + strTimestamp);
				PingTimestamp = null ;
			}
		}
			
		/**
		 * Return String respresentation
		 */
		public override string ToString ()
		{
			return "TransponderData--> ICAO:" + Icao + "  Latitude:" + Latitude + "  Longitude:" + Longitude + "  Altitude:"+Altitude; 
		}
	}
}
