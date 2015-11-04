using System;

namespace CollisionDetectionSystem
{
	public interface IAudioHandler
	{

		void OnAircraftWillIntersectInTimeEvent (float time);
		Threat DetermineThreatLevel(float time);
		Boolean PlayAudio(Threat threat);
	}
}

