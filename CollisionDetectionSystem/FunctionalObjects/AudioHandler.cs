#define TRACE 

using System;
using System.Diagnostics;

namespace CollisionDetectionSystem
{
	public class AudioHandler: IAudioHandler
	{
		#region IAudioHandler implementation

		//get time until intersection
		//call threat level
		public void OnAircraftWillIntersectInTimeEvent (double time, Position position)
		{
			Threat theLevel = DetermineThreatLevel (time);
			PlayAudio (theLevel, position);
		}

		//determines threat level and sends into playAudio if needed
		//time is in number seconds
		public Threat DetermineThreatLevel (double time)
		{
			
			//case for theat level determined  <30 for orange, < 60 for yellow, < 15 for red
			if (time > 60) {
				return Threat.none;
			} else if (time <= 60 && time > 30) {
				return Threat.yellow;
			} else if (time <= 30 && time > 15) {
				return Threat.orange;
			} else if (time <= 15 && time >= 0) {
				return Threat.red;
			} 
			//added this to warn inside overlap
			else if (time == -1) {
				return Threat.red;
			}
			else{
				return Threat.none;
			}
		}

		//send in an enum for threat level
		//return true if audio played else false
		public Boolean PlayAudio (Threat threat, Position position)
		{
			if (threat != Threat.none) {
				switch (threat) {
				case Threat.yellow:
					Trace.WriteLine ("Traffic! Traffic!");
					break;
				case Threat.orange:
					Trace.WriteLine ("Warning! Warning!");
					ReportCommand (position);
					break;
				case Threat.red:
					Trace.WriteLine ("Take Evasive Action Now!");
					ReportCommand (position);
					break;
				}
				return true;
			}
			else{
				return false;
			}
		}
		private void ReportCommand(Position position){
			if (position == Position.Above) {
				Trace.WriteLine ("Descend! Descend!");
			} 
			else {
				Trace.WriteLine ("Climb! Climb!");
			}
		}

		#endregion
	}
}

