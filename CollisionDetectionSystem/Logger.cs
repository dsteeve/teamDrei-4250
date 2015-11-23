using System;
using System.IO;

namespace CollisionDetectionSystem
{
	public class Logger
	{
		public StreamWriter toLog;
		string path = @"c:\CollisionSystemLog.txt";

		public Logger ()
		{
			if (File.Exists(path))
			{
				//removes the file if it exists 
				File.Delete(path);
			}	
			//creates the file
			FileStream.create (path);

			try{
				//attepts to create a stream writer that points at the file
				toLog = new StreamWriter (path);
			}
			catch(Exception E){
				throw;
			}

		}

		//write method that takes a string and an event that has a message, the log creates a line that is the concadination of the two.
		public void write(string line, BuildEventArgs message){
			toLog.WriteLine (line + message.Message);
		}

		//used to close the connection to the file
		public void shutDown(){
			toLog.Close ();
		}
}

