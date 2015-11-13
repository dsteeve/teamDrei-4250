using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Single;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class Aircraft
	{
		public string Identifier { get; private set; }
		public List<Vector<double>> DataBuffer { get; private set; } //Holds the last 20 coordinates
		public Vector<double> Velocity;

		public Aircraft (string identifier, Vector<double> velocity = null)
		{
			Identifier = identifier;
			Velocity = velocity;
			DataBuffer = new List<Vector<double>>();
		}
	}
}

