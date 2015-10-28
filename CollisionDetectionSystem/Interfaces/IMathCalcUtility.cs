using System;
using MathNet.Numerics.LinearAlgebra;
namespace CollisionDetectionSystem
{
	public interface IMathCalcUtility
	{
		double Intersection (Aircraft aircraft1, Aircraft aircraft2, double radius);
		double Distance (Vector<double> coordinate1, Vector<double> coordinate2);
		Vector<double> CalculateVector (Vector<double> data1, Vector<double> data2);
		Vector<double> CalculateCoordinate(double latitude, double longitude, double altitude);
	}
}

