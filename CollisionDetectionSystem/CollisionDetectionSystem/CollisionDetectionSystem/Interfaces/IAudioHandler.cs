using System;

namespace CollisionDetectionSystem
{
	public interface IAudioHandler
	{
		void OnAircraftWillIntersectInTimeEvent (float time);
		void DetermineThreatLevel(float time);
		void PlayAudio();
	}
}

