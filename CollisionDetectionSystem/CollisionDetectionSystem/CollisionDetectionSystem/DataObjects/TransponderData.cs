using System;

namespace CollisionDetectionSystem
{
	public class TransponderData
	{
		public double Longitude { get; private set; }
		public double Latitude { get; private set; }
		public double Altitude { get; private set; }
		public string Identifier { get; private set; }

		public TransponderData (double latitude, double longitude, double altitude, string identifier)
		{
			Latitude = latitude;
			Longitude = longitude;
			Altitude = altitude;
			Identifier = identifier;
		}
	}
}

