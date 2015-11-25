using System;
using System.IO;

namespace CollisionDetectionSystem
{
	public class Logger
	{
		string path = @"cds.log";

		public Logger ()
		{
			if (File.Exists(path))
			{
				//removes the file if it exists 
				File.Delete(path);
			}	
				
		}

		//write method that takes a string, write it out with a timestamp
		public  void log(string message){
			using (StreamWriter outputFile = new StreamWriter(path, true)) {
				outputFile.WriteLine( message);
			}
			//Dispose is automatically handled.
		}
	}
		
}

