using System;

/**
 * Represents the layout of the transponder data
 */

namespace CollisionDetectionSystem
{
	public class TransponderData
	{
		public DateTimeOffset PingTimestamp {  get; private set; }
		public string Identifier {  get; private set; }
		public double Longitude {  get; private set; }
		public double Latitude {  get; private set; }
		public double Altitude {  get; private set; }
		public string SquawkCode {  get; private set; }

		/** 
		 * constructor
		 */
		public TransponderData (string pingTimestamp, string identifier, double latitude, double longitude, double altitude, string squawkCode)
		{
			setPingTimestamp(pingTimestamp);
			Identifier = identifier;
			Longitude = longitude;
			Latitude = latitude;
			Altitude = altitude;
			SquawkCode = squawkCode;

		}

		private void setPingTimestamp (String strTimestamp){
			PingTimestamp = covertToDateTimeOffset (strTimestamp);
		}

		private DateTimeOffset covertToDateTimeOffset (String strTs) {
			DateTimeOffset dateTimeTzobj = new DateTimeOffset ();
			//TODO:  use the strTs to create the datetimeoffset.
			return dateTimeTzobj;
		}
	}
}
