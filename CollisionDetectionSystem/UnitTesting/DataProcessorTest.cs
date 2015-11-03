using System;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

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

	}
}