using System;

namespace CollisionDetectionSystem
{
	public class AudioHandler: IAudioHandler
	{
		#region IAudioHandler implementation

		//get time until intersection
		//call threat level
		public void OnAircraftWillIntersectInTimeEvent (float time)
		{
			DetermineThreatLevel (time);
			throw new NotImplementedException ();
		}

		//determines threat level and sends into playAudio if needed
		//time is in number seconds
		public void DetermineThreatLevel (float time)
		{
			//case for theat level determined 30 for orange, 60 for yellow, 15 for red
			throw new NotImplementedException ();
		}

		//send in an enum for threat level
		public void PlayAudio ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

