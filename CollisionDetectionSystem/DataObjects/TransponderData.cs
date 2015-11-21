using System;
using System.Text.RegularExpressions;

/**
 * Represents the layout of the transponder data
 */

namespace CollisionDetectionSystem
{
	public class TransponderData
	{
		public DateTime PingTimestamp {  get; private set; }
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

		private void setPingTimestamp (String strTimestamp){
			PingTimestamp = DateTime.Parse(strTimestamp);
		}

		//nothing calls this yet
		private DateTimeOffset covertToDateTimeOffset (String strTs) {
			DateTimeOffset dateTimeTzobj = new DateTimeOffset ();
			//TODO:  use the strTs to create the datetimeoffset.
			return dateTimeTzobj;
		}
	}
}
