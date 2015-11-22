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
//		[Test ()]
//		public void OnPostDataEventTest()
//		{
//			//Test to make sure the data processor recieved the data, converted the data to a coordinate,
//			//created an entry if needed in the intruder list, and then added the coordinate to the 
//			//intruders data buffer.
//
//			IDataProcessor dataProcessor = new DataProcessor ();
//
//			dataProcessor.ThisAircraft.DataBuffer.Add(Vector<double>.Build.Dense(3));
//			dataProcessor.OnPostDataEvent(new TransponderData ("00:00", "B1E24F", 0, 0, 0, "1200"));
//			dataProcessor.OnPostDataEvent(new TransponderData ("00:00", "B1E24F", 1, 0, 0, "1200"));
//
//			TransponderData data1 = new TransponderData ("00:00", "1A23", 1, 0, 0, "1200");
//			TransponderData data2 = new TransponderData ("00:00", "1B35", 2, 0, 0, "1200");
//			TransponderData data3 = new TransponderData ("00:00", "9C23", 3, 0, 0, "1200");
//			TransponderData data4 = new TransponderData ("00:00", "1A23", 2, 0, 0, "1200");
//
//			dataProcessor.OnPostDataEvent (data1);
//			Assert.AreEqual (1, dataProcessor.Intruders [0].DataBuffer [0] [0]);
//
//			dataProcessor.OnPostDataEvent (data2);
//			Assert.AreEqual (2, dataProcessor.Intruders [1].DataBuffer [0] [0]);
//
//			dataProcessor.OnPostDataEvent (data3);
//			Assert.AreEqual (3, dataProcessor.Intruders [2].DataBuffer [0] [0]);
//
//			//Added a second transponder data to the first intruder
//			dataProcessor.OnPostDataEvent (data4);
//			Assert.AreEqual (2, dataProcessor.Intruders [0].DataBuffer [1] [0]);
//
//		}

		[Test ()]
		public void OnPostDataEventTest2()
		{
			//Test to make sure the data processor recieved the data, converted the data to a coordinate,
			//created an entry if needed in the intruder list, and then added the coordinate to the 
			//intruders data buffer.

			IDataProcessor dataProcessor = new DataProcessor ();
			IAudioHandler audioHandler = new AudioHandler ();
			IRadarHandler radarHandler = new RadarHandler ();

			dataProcessor.AircraftDidEnterRadarRangeEvent += radarHandler.AircraftDidEnterRadarRangeEvent;
			dataProcessor.AircraftWillIntersectInTimeEvent += audioHandler.OnAircraftWillIntersectInTimeEvent;

			TransponderData thisAircraftData1 = new TransponderData ("00:00", "B1E24F", 90, 0, 8247.7, "1200");
			TransponderData thisAircraftData2 = new TransponderData ("00:00", "B1E24F", 89.9986, 0, 8247.8, "1200");
			TransponderData thisAircraftData3 = new TransponderData ("00:00", "B1E24F", 89.98212, 0, 8248, "1200");
			TransponderData thisAircraftData4 = new TransponderData ("00:00", "B1E24F", 89.97318, 0, 8248.4, "1200");
			TransponderData thisAircraftData5 = new TransponderData ("00:00", "B1E24F", 89.96423, 0, 8248.9, "1200");

			TransponderData intruderData1 = new TransponderData ("00:00", "1A23", 89.92847, 0, 8252.7, "1200");
			TransponderData intruderData2 = new TransponderData ("00:00", "1A23", 89.93741, 0, 8251.5, "1200");
			TransponderData intruderData3 = new TransponderData ("00:00", "1A23", 89.94635, 0, 8250.5, "1200");
			TransponderData intruderData4 = new TransponderData ("00:00", "1A23", 89.95529, 0, 8249.6, "1200");
			TransponderData intruderData5 = new TransponderData ("00:00", "1A23", 89.96423, 0, 8248.9, "1200");

			dataProcessor.ThisAircraft.DataBuffer.Add(Vector<double>.Build.DenseOfArray(new double[3]{0, 0, 6365}));

			var list1 = new  List<TransponderData> ();
			var list2 = new  List<TransponderData> ();
			var list3 = new  List<TransponderData> ();
			var list4 = new  List<TransponderData> ();
			var list5 = new  List<TransponderData> ();

			list1.Add (thisAircraftData1);
			list1.Add (intruderData1);
			list2.Add (thisAircraftData2);
			list2.Add (intruderData2);
			list3.Add (thisAircraftData3);
			list3.Add (intruderData3);
			list4.Add (thisAircraftData4);
			list4.Add (intruderData4);
			list5.Add (thisAircraftData5);
			list5.Add (intruderData5);

			dataProcessor.OnPostDataEvent (list1);
			dataProcessor.OnPostDataEvent (list2);
			dataProcessor.OnPostDataEvent (list3);
			dataProcessor.OnPostDataEvent (list4);
			dataProcessor.OnPostDataEvent (list5);
		}


	}
}