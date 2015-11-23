using System;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class MathCalcUtility : IMathCalcUtility
	{
		#region IMathCalcUtility implementation

		//This doesn't work yet, math isnt quite right. Need starting coordinate as well as vector
		//to make any since. Must of missed something in my notes - Stephen
		public double Intersection (Aircraft aircraft1, Aircraft aircraft2, double radius)
		{
			//Positions
			Vector<double> c1 = Vector<double>.Build.DenseOfArray(new double[3]{aircraft1.DataBuffer[0][0], aircraft1.DataBuffer[0][1], aircraft1.DataBuffer[0][2]});
			Vector<double> c2 = Vector<double>.Build.DenseOfArray(new double[3]{aircraft2.DataBuffer[0][0], aircraft2.DataBuffer[0][1], aircraft2.DataBuffer[0][2]});

			//Console.WriteLine ("aircraft1-us vector" + c1);
			//Console.WriteLine ("aircraft2-them  vector" + c2);

			//Velocities
			Vector<double> v1 = aircraft1.Velocity;
			Vector<double> v2 = aircraft2.Velocity;

			//Console.WriteLine ("aircraft1-us velocity" + v1);
			//Console.WriteLine ("aircraft2-them velocity" + v2);

			Vector<double> d = c1.Subtract (c2);
			Vector<double> w = v1.Subtract (v2);

			double dDotW = (d.DotProduct (w));
			double wDotW = (w.DotProduct (w));
			double dDotD = (d.DotProduct (d));

			//Console.WriteLine(
			double decider = Math.Pow(dDotW, 2) - (wDotW * (dDotD - Math.Pow(radius, 2)));
			if (decider < 0) {
				//No intersection if negative
				return -1;
			}

			double plusResult = -1 * dDotW + Math.Sqrt(decider) / wDotW;
			double minusResult = -1 * dDotW - Math.Sqrt(decider) / wDotW; //I believe this is when they first touch, the plus result is when they exit.

			if (minusResult < 0) {
				return -1; //No intersection
			} else {
				return minusResult;
			}
		}

		public Vector<double> CalculateVector (Vector<double> coordinateFrom, Vector<double> coordinateTo)
		{
			double x = Math.Round(coordinateTo[0] - coordinateFrom[0], 7);
			double y = Math.Round(coordinateTo[1] - coordinateFrom[1], 7);
			double z = Math.Round(coordinateTo[2] - coordinateFrom[2], 7);

			return Vector<double>.Build.DenseOfArray(new double[3]{x, y, z});

		}

		//LLA to ECEF conversion. Reference: http://www.mathworks.com/help/aeroblks/llatoecefposition.html
		//This is good to http://includesoft.com/DSP/ecef_calculation_for_range_and_b.htm
		public Vector<double> CalculateCoordinate(double latitude, double longitude, double altitude){

            //convert altitude to meters
            altitude = altitude * .3048;

			double radius = 6378137.0; //radius of earth in meters.
			double flatteningFactor = 1.0 / 298.257223563; //Flattening factor WGS84 Model.
			double cosLat = Math.Cos (latitude * Math.PI / 180.0);
			double sinLat = Math.Sin (latitude * Math.PI / 180.0);
			double FF = Math.Pow((1.0 - flatteningFactor), 2);
			double C = 1 / Math.Sqrt (Math.Pow (cosLat, 2) + (FF * Math.Pow(sinLat, 2)));
			double S = C * FF;

			//Result in Kilometers
			double xk = Math.Round(((radius * C) + altitude) * cosLat * Math.Cos (longitude * Math.PI / 180) / 1000, 3);
			double yk = Math.Round(((radius * C) + altitude) * cosLat * Math.Sin (longitude * Math.PI / 180) / 1000, 3);
			double zk = Math.Round(((radius * S) + altitude) * sinLat / 1000, 3);

			//Result in Nautical miles
			double x = Math.Round(xk * 0.539957, 4);
			double y = Math.Round(yk * 0.539957, 4);
			double z = Math.Round(zk * 0.539957, 4);

			return Vector<double>.Build.DenseOfArray (new double[3]{ x, y, z });
		}

		/**
		 * Calculate Distance between 2 vectors
		 * Returns distance in NM's
		 */
		public double Distance(Vector<double> coordinate1, Vector<double> coordinate2){

			double xSquared = Math.Pow (coordinate1 [0] - coordinate2 [0], 2);
			double ySquared = Math.Pow (coordinate1 [1] - coordinate2 [1], 2);
			double zSquared = Math.Pow (coordinate1 [2] - coordinate2 [2], 2);

			//Result is in whatever the coordinates were calculated in. (nm's)
			double nms = Math.Round(Math.Sqrt (xSquared + ySquared + zSquared), 3); 
			return nms;
		}

		#endregion
	}
}

