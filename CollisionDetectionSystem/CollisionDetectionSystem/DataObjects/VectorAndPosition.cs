using System;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	public class VectorAndPosition
	{
		public Vector<double> Position { get; set; }
		public Vector<double> Velocity { get; set; }

		public VectorAndPosition (Vector<double> position, Vector<double> velocity)
		{
			Position = position;
			Velocity = velocity;
		}
	}
}

