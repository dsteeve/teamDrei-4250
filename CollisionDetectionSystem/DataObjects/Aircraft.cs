using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Single;
using MathNet.Numerics.LinearAlgebra;

namespace CollisionDetectionSystem
{
	/**
	 * Aircraft data
	 */
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

		public override string ToString ()
		{
			return "Aircraft Data--> Identifier: " + Identifier + "  Velocity: " + Velocity ; 
		}

		private String toString(List<Vector<double>> buf){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			foreach (Vector<double> vect in buf) {
				foreach (Double d in vect) {
					sb.Append(d);
					sb.Append(", ");
				}
				sb.AppendLine ();  
			}
			return sb.ToString ();
		}
	}
}

