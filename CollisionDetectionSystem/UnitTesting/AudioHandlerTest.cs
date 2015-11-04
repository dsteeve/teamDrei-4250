using NUnit.Framework;
using System;
using MathNet.Numerics.LinearAlgebra;
using CollisionDetectionSystem;

namespace UnitTesting
{
	[TestFixture ()]
	public class AudioHandlerTest
	{
		//testing the determineThreatLevel
		[Test ()]
		public void noAlert ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Threat threat = audHandler.DetermineThreatLevel (75);
			Assert.AreEqual ( Threat.none, threat);

		}
		[Test ()]
		public void redAlert ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Threat threat = audHandler.DetermineThreatLevel (15);
			Assert.AreEqual ( Threat.red, threat);

		}
		[Test ()]
		public void redAlert2 ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Threat threat = audHandler.DetermineThreatLevel (0);
			Assert.AreEqual ( Threat.red, threat);

		}
		[Test ()]
		public void orangeAlert ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Threat threat = audHandler.DetermineThreatLevel (30);
			Assert.AreEqual ( Threat.orange, threat);

		}
		[Test ()]
		public void yellowAlert ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Threat threat = audHandler.DetermineThreatLevel (60);
			Assert.AreEqual ( Threat.yellow, threat);

		}
		[Test ()]
		public void tooLateAlert ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Threat threat = audHandler.DetermineThreatLevel (-1);
			Assert.AreEqual ( Threat.red, threat);

		}
		//testing the play audio method 
		[Test ()]
		public void playAudioYellow ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Boolean played = audHandler.PlayAudio (Threat.yellow);
			Assert.AreSame (played, true);
		}
		[Test ()]
		public void playAudioOrange ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Boolean played = audHandler.PlayAudio (Threat.orange);
			Assert.AreSame (played, true);
		}
		[Test ()]
		public void playAudioRed ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Boolean played = audHandler.PlayAudio (Threat.red);
			Assert.AreSame (played, true);
		}

		[Test ()]
		public void playAudioNoThreat ()
		{
			AudioHandler audHandler = new AudioHandler (); 
			Boolean played = audHandler.PlayAudio (Threat.none);
			Assert.AreSame (played, false);
		}
	}
}

