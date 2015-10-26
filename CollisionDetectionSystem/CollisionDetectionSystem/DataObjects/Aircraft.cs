using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Single;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class Aircraft
	{
		public string Identifier { get; private set; }
		public List<TransponderData> DataBuffer { get; private set; } //Holds the last 20 transponder data
		public Vector<double> Velocity;

		public Aircraft (string identifier, Vector<double> velocity)
		{
			Identifier = identifier;
			Velocity = velocity;
			DataBuffer = new List<TransponderData> ();
		}
	}
}

