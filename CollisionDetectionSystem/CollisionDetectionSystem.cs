using System;
using MathNet.Numerics.LinearAlgebra;


namespace CollisionDetectionSystem
{
	public class CollisionDetectionSystem
	{
		private IAudioHandler AudioHandler { get; set; }
		private IDataProcessor DataProcessor { get; set; }
		private IRadarHandler RadarHandler { get; set; }
		private ITransponderReceiver TransponderReceiver { get; set; }
		private IMockTransponder MockTransponder { get; set; }

		public CollisionDetectionSystem ()
		{
			AudioHandler = new AudioHandler ();
			DataProcessor = new DataProcessor ();
			RadarHandler = new RadarHandler ();
			TransponderReceiver = new TransponderReceiver ();
			MockTransponder = new MockTransponder ();
		}

		/**
		 * start in normal mode
		 * 
		 */
		public void Start(){
			SetupDelegates ();
		}

		/**
		 * Start in test mode
		 * 
		 */
		public void Start(String testdirname){
			Start ();

			if (String.IsNullOrEmpty (testdirname) || String.IsNullOrWhiteSpace(testdirname)) {
				return;
			} else {
				StartMockTransponder (testdirname.Trim());
				SetupTestDelegates ();
			}
		}

		//Sets up all the delegate events, when one of these delegate events are called all methods
		//that have been assigned to that delegate will be called even if they're from different objects. C# awesomeness!
		void SetupDelegates(){
			MockTransponder.SendDataEvent += TransponderReceiver.ReceiveData;
			TransponderReceiver.PostDataEvent += DataProcessor.OnPostDataEvent;
			DataProcessor.AircraftDidEnterRadarRangeEvent += RadarHandler.AircraftDidEnterRadarRangeEvent;
			DataProcessor.AircraftWillIntersectInTimeEvent += AudioHandler.OnAircraftWillIntersectInTimeEvent;
		}

		void SetupTestDelegates(){
			//todo:  wireup radar and audio handlers to testharness
		}

		/**
		 * start the mock transponder and act like we are hearing 
		 * actual transponder pings
		 * 
		 */
		void StartMockTransponder(String testDirName){
			MockTransponder.Start (testDirName);
		}
			
	}
}

