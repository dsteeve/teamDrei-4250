using System;

namespace CollisionDetectionSystem
{
	public interface IAudioHandler
	{

		void OnAircraftWillIntersectInTimeEvent (double time);
		Threat DetermineThreatLevel(double time);
		Boolean PlayAudio(Threat threat);
	}
}

