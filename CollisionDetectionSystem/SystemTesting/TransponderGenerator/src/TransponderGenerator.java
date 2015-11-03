import java.io.IOException;
import java.util.Scanner;
import java.util.Calendar;

/*
  This is a throw away program meant to help generate our system test files
  This program does not represent the collision detection system in any way
  it is simply meant as a time saving utility in creating system test situations.
  The formulas were found online at http://www.movable-type.co.uk/scripts/latlong.html
*/
public class TransponderGenerator {

	public static void main(String[] args) {
		//start program
		Scanner in = new Scanner(System.in);
		char quit = 'n';
		//Main menu loop
		do{
		System.out.println("What would you like to do?");
		System.out.println("1. Find Nautical Miles between two points (altitude factored in)");
		System.out.println("2. Find Nautical Miles between two points (altitude ignored)");
		System.out.println("3. Find future lat/lon given starting lat/lon, bearing, knots and time");
		System.out.println("4. Find initial bearing between start and end lat/lon");
		System.out.println("5. Find final bearing between start and end lat/lon");
		System.out.println("6. Generate Intersection");
		System.out.println("7. Generate Single Flight");
		System.out.println("8. Get Speed");
		System.out.println("9. Quit");
		int choice = in.nextInt();
		switch (choice) {
		case 1: FindDistance(in);
				break;
		case 2: FindDistance2D(in);
				break;
		case 3: FindFuturePoint(in);
				break;
		case 4: FindInitBearing(in);
				break;
		case 5: FindFinalBearing(in);
				break;
		case 6: GenerateIntersection(in);
				break;
		case 7: GenerateFlight(in);
				break;
		case 8: FindSpeed(in);
				break;
		case 9: quit = 'y';
				break;
				
		}
		//quit?
		}while(quit != 'y');
				
	}
	
	//menu item 1
	private static void FindDistance(Scanner in){
		double lat1;
		double lat2;
		double lon1;
		double lon2;
		double el1;
		double el2;
	
		System.out.println("Enter latitude for plane 1 (positive or negative): ");
		lat1 = in.nextDouble();
	
		System.out.println("Enter longitude for plane 1 (positive or negative): ");
		lon1 = in.nextDouble();
	
		System.out.println("Enter altitude for plane 1 (positive): ");
		el1 = in.nextDouble();
	
		System.out.println("Enter latitude for plane 2 (positive or negative): ");
		lat2 = in.nextDouble();
	
		System.out.println("Enter longitude for plane 2 (positive or negative): ");
		lon2 = in.nextDouble();
	
		System.out.println("Enter altitude for plane 2 (positive): ");
		el2 = in.nextDouble();
	
		System.out.print("Distance in nautical miles between plane 1 and plane 2 (altitude difference factored in) is: ");
		
		System.out.print(String.format("%1$,.6f",DistanceCalculator.distancecalc(lat1,lat2,lon1, lon2, el1, el2)/1852));
		
		System.out.print(" nautical miles.\n");
		
		System.out.println("Press enter to continue...");
		try {
			System.in.read();
			} catch (IOException e) {
		e.printStackTrace();
		}
	}
	//menu item 2
	private static void FindDistance2D(Scanner in){
		double lat1;
		double lat2;
		double lon1;
		double lon2;
		
		System.out.println("Enter latitude for plane 1 (positive or negative): ");
		lat1 = in.nextDouble();
	
		System.out.println("Enter longitude for plane 1 (positive or negative): ");
		lon1 = in.nextDouble();
	
		System.out.println("Enter latitude for plane 2 (positive or negative): ");
		lat2 = in.nextDouble();
	
		System.out.println("Enter longitude for plane 2 (positive or negative): ");
		lon2 = in.nextDouble();
	
		System.out.print("Distance in nautical miles between plane 1 and plane 2 is: ");
		
		System.out.print(String.format("%1$,.6f",DistanceCalculator.distancecalc2D(lat1,lat2,lon1, lon2)/1852));
	
		System.out.print(" nautical miles.\n");
	
		System.out.println("Press enter to continue...");
		try {
			System.in.read();
			} catch (IOException e) {
		e.printStackTrace();
		}
	}

	
	
	//menu item 3
	private static void FindFuturePoint(Scanner in){
		
		double lat;
		double lon;
		double bearing;
		double knots;
		double time;
	
		System.out.println("Enter Latitude (positive or negative):");
		lat = in.nextDouble();
	
		System.out.println("Enter Longitude (positive or negative):");
		lon = in.nextDouble();
	
		System.out.println("Enter Bearing (in decimal degrees):");
		bearing = in.nextDouble();
	
		System.out.println("Enter Nautical Miles per Hour:");
		knots = in.nextDouble();
	
		System.out.println("Enter Time (in decimal hours) i.e. 1.5 = 90 minutes:");
		time = in.nextDouble();
	
		Coord result = DistanceCalculator.FuturePoint(lat, lon, bearing, knots, time);
		
		System.out.print("Ending Latitude (considering inital bearing): ");
	
		System.out.print(String.format("%1$,.6f",result.getLat()) + "\n");
	
		System.out.print("Ending Longitude (considering initial bearing): ");
	
		System.out.print(String.format("%1$,.6f",result.getLon()) + "\n");
	
		System.out.println("Press enter to continue...");
	
		try {
			System.in.read();
			} catch (IOException e) {
		e.printStackTrace();
		}
	}
	//menu item 4
	private static void FindInitBearing(Scanner in){
		
		double lat1;
		double lon1;
		double lat2;
		double lon2;
		
		System.out.println("Enter Starting Latitude (positive or negative):");
		lat1 = in.nextDouble();
		
		System.out.println("Enter Starting Longitude (positive or negative):");
		lon1 = in.nextDouble();
		
		System.out.println("Enter Ending Latitude (positive or negative):");
		lat2 = in.nextDouble();
		
		System.out.println("Enter Ending Longitude (positive or negative):");
		lon2 = in.nextDouble();
		
		System.out.print("The initial bearing is: ");
		
		System.out.print(String.format("%1$,.6f",DistanceCalculator.calcInitBearing(lat1,lat2,lon1,lon2)));
		
		System.out.print(" (decimal degrees).\n");
		
		System.out.println("Press enter to continue...");
		
		try {
			System.in.read();
			} catch (IOException e) {
		e.printStackTrace();
			}
		}
		//menu item 5
		private static void FindFinalBearing(Scanner in){
		
		double lat1;
		double lon1;
		double lat2;
		double lon2;
		
		System.out.println("Enter Starting Latitude (positive or negative):");
		lat1 = in.nextDouble();

		System.out.println("Enter Starting Longitude (positive or negative):");
		lon1 = in.nextDouble();
		
		System.out.println("Enter Ending Latitude (positive or negative):");
		lat2 = in.nextDouble();
		
		System.out.println("Enter Ending Longitude (positive or negative):");
		lon2 = in.nextDouble();
		
		System.out.print("The final bearing is: ");
		
		System.out.print(String.format("%1$,.6f",DistanceCalculator.calcFinalBearing(lat1,lat2,lon1,lon2)));
	
		System.out.print(" (decimal degrees).\n");
		
		System.out.println("Press enter to continue...");
		try {
			System.in.read();
			} catch (IOException e) {
		e.printStackTrace();
			}
		}
		//menu item 6
		private static void GenerateIntersection(Scanner in){
			double intersectLat;
			double intersectLon;
			double plane1IntersectAlt;
			double plane2IntersectAlt;
			double plane1StartLat;
			double plane1StartLon;
			double plane1StartAlt;
			double plane2StartLat;
			double plane2StartLon;
			double plane2StartAlt;
			double timeTillIntersection;
			double pollContinue;
			double pollingInterval;
			String plane1ICAOHex;
			String plane2ICAOHex;
			String plane1ID;
			String plane2ID;
	
		
			System.out.println("Enter our plane's ID (6 digit alpha numeric): ");
			plane1ID = in.next();

			System.out.println("Enter intruder's ID (6 digit alpha numeric): ");
			plane2ID = in.next();
			
			System.out.println("Enter our plane's ICAO hex code (6 digit hex address):");
			plane1ICAOHex = in.next();
			
			System.out.println("Enter intruder's ICAO hex code (6 digit hex address):");
			plane2ICAOHex = in.next();
		
			System.out.println("Enter Intersection Latitude (positive or negative):");
			intersectLat = in.nextDouble();
			
			System.out.println("Enter Intersection Longitude (positive or negative):");
			intersectLon = in.nextDouble();
			
			System.out.println("Enter Altitude of our plane at intersection (positive):");
			plane1IntersectAlt = in.nextDouble();
			
			System.out.println("Enter Altitude of intruder at intersection (positive):");
			plane2IntersectAlt = in.nextDouble();
		
			System.out.println("Enter our plane's starting latitude (positive or negative):");
			plane1StartLat = in.nextDouble();
			
			System.out.println("Enter our plane's starting longitude (positive or negative):");
			plane1StartLon = in.nextDouble();
			
			System.out.println("Enter our plane's starting altitude (positive or negative):");
			plane1StartAlt = in.nextDouble();
		
			System.out.println("Enter intruder's starting latitude (positive or negative):");
			plane2StartLat = in.nextDouble();
			
			System.out.println("Enter intruder's starting longitude (positive or negative):");
			plane2StartLon = in.nextDouble();
			
			System.out.println("Enter intruder's starting altitude (positive or negative):");
			plane2StartAlt = in.nextDouble();
		
			System.out.println("Enter time until intersection (in seconds): ");
			timeTillIntersection = in.nextDouble();
		
			System.out.println("Enter time to continue generating after intersection (in seconds, positive [0 to stop at intersection]");
			pollContinue = in.nextDouble();
		
			System.out.println("Enter polling interval (in decimal seconds i.e. .5 = half a second");
			pollingInterval = in.nextDouble();
		
			double plane1StartBearing = DistanceCalculator.calcInitBearing(plane1StartLat,intersectLat,plane1StartLon,intersectLon);
			
			double plane2StartBearing = DistanceCalculator.calcInitBearing(plane2StartLat,intersectLat,plane2StartLon,intersectLon);
		
			double totalTime = timeTillIntersection + pollContinue;
			
			double plane1AltSubdivisions = (plane1IntersectAlt - plane1StartAlt) / (timeTillIntersection / pollingInterval);
			
			double plane2AltSubdivisions = (plane2IntersectAlt - plane2StartAlt) / (timeTillIntersection / pollingInterval);
			
			FileGenerator(totalTime,pollingInterval,plane1StartBearing,timeTillIntersection,plane1AltSubdivisions,
					plane1StartLat,plane1StartLon,intersectLat,intersectLon,plane1ICAOHex,plane1ID,plane1StartAlt,in);
		
			FileGenerator(totalTime,pollingInterval,plane2StartBearing,timeTillIntersection,plane2AltSubdivisions,
					plane2StartLat,plane2StartLon,intersectLat,intersectLon,plane2ICAOHex,plane2ID,plane2StartAlt,in);
		
			}
		//menu item 7
		private static void GenerateFlight(Scanner in){
			double intersectLat;
			double intersectLon;
			double plane1IntersectAlt;
			double plane1StartLat;
			double plane1StartLon;
			double plane1StartAlt;
			double timeTillIntersection;
			double pollContinue;
			double pollingInterval;
			String plane1ICAOHex;
			String plane1ID;
			
	
			System.out.println("Enter our plane's ID (6 digit alpha numeric): ");
			plane1ID = in.next();

			System.out.println("Enter our plane's ICAO hex code (6 digit hex address):");
			plane1ICAOHex = in.next();

			System.out.println("Enter Intersection Latitude (positive or negative):");
			intersectLat = in.nextDouble();
			
			System.out.println("Enter Intersection Longitude (positive or negative):");
			intersectLon = in.nextDouble();
			
			System.out.println("Enter Altitude of our plane at intersection (positive):");
			plane1IntersectAlt = in.nextDouble();

	
			System.out.println("Enter our plane's starting latitude (positive or negative):");
			plane1StartLat = in.nextDouble();
			
			System.out.println("Enter our plane's starting longitude (positive or negative):");
			plane1StartLon = in.nextDouble();
			
			System.out.println("Enter our plane's starting altitude (positive or negative):");
			plane1StartAlt = in.nextDouble();
	
	
			System.out.println("Enter time until intersection (in seconds): ");
			timeTillIntersection = in.nextDouble();
	
			System.out.println("Enter time to continue generating after intersection (in seconds, positive [0 to stop at intersection]");
			pollContinue = in.nextDouble();
	
			System.out.println("Enter polling interval (in decimal seconds i.e. .5 = half a second");
			pollingInterval = in.nextDouble();
	
			double plane1StartBearing = DistanceCalculator.calcInitBearing(plane1StartLat,intersectLat,plane1StartLon,intersectLon);

			double totalTime = timeTillIntersection + pollContinue;

			double plane1AltSubdivisions = (plane1IntersectAlt - plane1StartAlt) / (timeTillIntersection / pollingInterval);
	
			FileGenerator(totalTime,pollingInterval,plane1StartBearing,timeTillIntersection,plane1AltSubdivisions,
					plane1StartLat,plane1StartLon,intersectLat,intersectLon,plane1ICAOHex,plane1ID,plane1StartAlt, in);
	
			}
		//menu item 8
		private static void FindSpeed(Scanner in){
			double lat; 
			double lon;
			double latIntersect; 
			double lonIntersect;
			double timeTillIntersection;

			System.out.println("Enter Intersection Latitude: ");
			latIntersect = in.nextDouble();
			
			System.out.println("Enter Intersection Longitude: ");
			lonIntersect = in.nextDouble();
			
			System.out.println("Enter Starting Latitude: ");
			lat = in.nextDouble();
			
			System.out.println("Enter Starting Longitude: ");
			lon = in.nextDouble();
			
			System.out.println("Enter Time until Intersection: ");
			timeTillIntersection = in.nextDouble();
		
			System.out.println("Speed is: " + 
			((DistanceCalculator.distancecalc2D(lat, latIntersect, lon, lonIntersect)/1852)/timeTillIntersection) * 3600
			+ " nautical miles per hour.");
		}
		
		//file generator
		private static void FileGenerator(double totalTime, double interval, double startBearing, double timeTillIntersection,
								  double altSubdivision, double lat, double lon, double latIntersect, double lonIntersect,
								  String ICAO, String ID,double alt,Scanner in){
		
		int hours = 12;
		int min = 0;
		int sec = 0;
		int milliseconds = 0;
		
		System.out.println("Would you like to enter starting time? (Y/y for yes)");
		if(in.next().equalsIgnoreCase("Y")){
			System.out.println("Enter hours: ");
				hours = in.nextInt();
			System.out.println("Enter minutes: ");
				min = in.nextInt();
			System.out.println("Enter seconds: ");
				sec = in.nextInt();
			System.out.println("Enter milliseconds: ");
				milliseconds = in.nextInt();
		}
	
		Calendar time = Calendar.getInstance();
		time.set(2015, 1, 1, hours, min, sec);
		time.set(Calendar.MILLISECOND, milliseconds);
		
		double speed = (DistanceCalculator.distancecalc2D(lat, latIntersect, lon, lonIntersect)/1852)/timeTillIntersection;
		
		System.out.println("Speed is near: " + String.format("%1$,.2f", (speed * 3600)) + " nautical miles per hour");
		
		System.out.print(String.format("%02d",time.get(Calendar.HOUR_OF_DAY)));
		
		System.out.print(":");
		
		System.out.print(String.format("%02d",time.get(Calendar.MINUTE)));
		
		System.out.print(":");
		
		System.out.print(String.format("%02d",time.get(Calendar.SECOND)));
		
		System.out.print("Z.");
		
		System.out.print(String.format("%03d",time.get(Calendar.MILLISECOND)));
		
		System.out.print(" T,");
		
		System.out.print(ICAO);
		
		System.out.print(",");
		
		System.out.print(String.format("%1$,.6f",lat) + "," + String.format("%1$,.6f",lon) + ",");
		
		System.out.print((int)alt + "," + ID + "\n");
		
		Coord result;

		while(totalTime > 0){
			
			result = DistanceCalculator.FuturePoint(lat, lon, startBearing, speed, interval);
			alt = alt + altSubdivision;
			time.add(Calendar.MILLISECOND,(int)(interval * 1000));
			totalTime = totalTime - interval;
				startBearing = DistanceCalculator.calcFinalBearing(lat, result.getLat(), lon, result.getLon());
			lat = result.getLat();
			lon = result.getLon();
			System.out.print(String.format("%02d",time.get(Calendar.HOUR_OF_DAY)));
			System.out.print(":");
			System.out.print(String.format("%02d",time.get(Calendar.MINUTE)));
			System.out.print(":");
			System.out.print(String.format("%02d",time.get(Calendar.SECOND)));
			System.out.print("Z.");
			System.out.print(String.format("%03d",time.get(Calendar.MILLISECOND)));
			System.out.print(" T,");
			System.out.print(ICAO);
			System.out.print(",");
			System.out.print(String.format("%1$,.6f",lat) + "," + String.format("%1$,.6f",lon) + ",");
			System.out.print((int)alt + "," + ID + "\n");
		}
		
}

}
