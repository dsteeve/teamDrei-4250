using System;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;
using System.Collections.Generic;
using System.Timers;

namespace UnitTesting
{
	[TestFixture ()]
	public class TransponderRecieverTimerTest
	{
		TransponderReceiver Reciever;

		[Test ()]
		public void TimerTest ()
		{
			Reciever = new TransponderReceiver ();
			Reciever.StartTimer ();
			StartTimer ();
		}

		public void StartTimer(){
			Timer myTimer = new Timer();
			myTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
			myTimer.Interval = 200;
			myTimer.Start();
		}

		public void TimeEvent(object source, ElapsedEventArgs e)
		{
			Reciever.ReceiveData(new TransponderData("0", "1", 0, 0, 0, "1200"));
			Console.Error.WriteLine ("test");
			Console.WriteLine ("test");
		}
	}

}

