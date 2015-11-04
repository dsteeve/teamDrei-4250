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
			Threat theLevel = DetermineThreatLevel (time);
			PlayAudio (theLevel);

		}

		//determines threat level and sends into playAudio if needed
		//time is in number seconds
		public Threat DetermineThreatLevel (float time)
		{
			//case for theat level determined  <30 for orange, < 60 for yellow, < 15 for red
			return Threat.none;
		}

		//send in an enum for threat level
		//return true if audio played else false
		public Boolean PlayAudio (Threat threat)
		{
			return false;
		}

		#endregion
	}
}

