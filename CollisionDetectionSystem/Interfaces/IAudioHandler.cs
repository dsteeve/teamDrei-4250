using System;

namespace CollisionDetectionSystem
{
	public interface IAudioHandler
	{

		void OnAircraftWillIntersectInTimeEvent (double time, Position position);
		Threat DetermineThreatLevel(double time);
		Boolean PlayAudio(Threat threat, Position position);
	}
}

