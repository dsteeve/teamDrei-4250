using System;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;
using System.Collections.Generic;

namespace UnitTesting
{
	[TestFixture ()]
	public class DataProcessorTest
	{
		[Test ()]
		public void OnPostDataEventTest()
		{
			//Test to make sure the data processor recieved the data, converted the data to a coordinate,
			//created an entry if needed in the intruder list, and then added the coordinate to the 
			//intruders data buffer.

			IDataProcessor dataProcessor = new DataProcessor ();

			dataProcessor.ThisAircraft.DataBuffer.Add(Vector<double>.Build.Dense(3));
			dataProcessor.OnPostDataEvent(new TransponderData ("00:00", "B1E24F", 0, 0, 0, "1200"));
			dataProcessor.OnPostDataEvent(new TransponderData ("00:00", "B1E24F", 1, 0, 0, "1200"));

			TransponderData data1 = new TransponderData ("00:00", "1A23", 1, 0, 0, "1200");
			TransponderData data2 = new TransponderData ("00:00", "1B35", 2, 0, 0, "1200");
			TransponderData data3 = new TransponderData ("00:00", "9C23", 3, 0, 0, "1200");
			TransponderData data4 = new TransponderData ("00:00", "1A23", 2, 0, 0, "1200");

			dataProcessor.OnPostDataEvent (data1);
			Assert.AreEqual (1, dataProcessor.Intruders [0].DataBuffer [0] [0]);

			dataProcessor.OnPostDataEvent (data2);
			Assert.AreEqual (2, dataProcessor.Intruders [1].DataBuffer [0] [0]);

			dataProcessor.OnPostDataEvent (data3);
			Assert.AreEqual (3, dataProcessor.Intruders [2].DataBuffer [0] [0]);

			//Added a second transponder data to the first intruder
			dataProcessor.OnPostDataEvent (data4);
			Assert.AreEqual (2, dataProcessor.Intruders [0].DataBuffer [1] [0]);

		}

		[Test ()]
		public void OnPostDataEventTest2()
		{
			//Test to make sure the data processor recieved the data, converted the data to a coordinate,
			//created an entry if needed in the intruder list, and then added the coordinate to the 
			//intruders data buffer.

//			IDataProcessor dataProcessor = new DataProcessor ();
//			IAudioHandler audioHandler = new AudioHandler ();
//			IRadarHandler radarHandler = new RadarHandler ();
//
//			dataProcessor.AircraftDidEnterRadarRangeEvent += radarHandler.AircraftDidEnterRadarRangeEvent;
//			dataProcessor.AircraftWillIntersectInTimeEvent += audioHandler.OnAircraftWillIntersectInTimeEvent;
//
//			TransponderData intruderData1 = new TransponderData ("00:00", "1A23", 89.99428, 0, 43643247.9, "1200");
//			TransponderData intruderData2 = new TransponderData ("00:00", "1A23", 89.99542, 0, 43643247.8, "1200");
//
//			dataProcessor.ThisAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{0, 0, 50000}));
//
//			var list1 = new  List<TransponderData> ();
//			var list2 = new  List<TransponderData> ();
//			var list3 = new  List<TransponderData> ();
//			var list4 = new  List<TransponderData> ();
//
//			list1.Add (new TransponderData ("00:00", "B1E24F", 90, 0, 43643247.7, "1200"));
//			list2.Add (intruderData1);
//			list3.Add (new TransponderData ("00:00", "B1E24F", 89.9986, 0, 43643247.7, "1200"));
//			list4.Add (intruderData2);

			//dataProcessor.OnPostDataEvent(list1);
			//dataProcessor.OnPostDataEvent (list2);
			//dataProcessor.OnPostDataEvent(list3);
			//dataProcessor.OnPostDataEvent (list4);
		}

	}
}