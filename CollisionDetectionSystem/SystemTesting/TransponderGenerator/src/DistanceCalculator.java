//static methods for calculations
//formulas found at http://www.movable-type.co.uk/scripts/latlong.html

public class DistanceCalculator {
	public static double distancecalc(double lat1, double lat2, double lon1,
	        double lon2, double el1, double el2) {

	    final int R = 6371; // Radius of the earth

	    Double latDistance = Math.toRadians(lat2 - lat1);
	    Double lonDistance = Math.toRadians(lon2 - lon1);
	    Double a = Math.sin(latDistance / 2) * Math.sin(latDistance / 2)
	            + Math.cos(Math.toRadians(lat1)) * Math.cos(Math.toRadians(lat2))
	            * Math.sin(lonDistance / 2) * Math.sin(lonDistance / 2);
	    Double c = 2 * Math.atan2(Math.sqrt(a),Math.sqrt(1 - a));
	    double distance = R * c * 1000; // convert to meters

	    double height = el1 - el2;

	    distance = Math.pow(distance, 2) + Math.pow(height, 2);

	    return Math.sqrt(distance);
	}
	
	public static double distancecalc2D(double lat1, double lat2, double lon1,
	        double lon2) {

	    final int R = 6371; // Radius of the earth

	    Double latDistance = Math.toRadians(lat2 - lat1);
	    Double lonDistance = Math.toRadians(lon2 - lon1);
	    Double a = Math.sin(latDistance / 2) * Math.sin(latDistance / 2)
	            + Math.cos(Math.toRadians(lat1)) * Math.cos(Math.toRadians(lat2))
	            * Math.sin(lonDistance / 2) * Math.sin(lonDistance / 2);
	    Double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
	    double distance = R * c * 1000; // convert to meters

	    return distance;
	}
	
	public static Coord FuturePoint(double Latitude, double Longitude, double initBearing, double knots, double time){
		Coord futureCoord = new Coord();
		final double radiusEarth = 6371;
		final double kmPerHourPerKnot = 1.852;
		double distance = (knots * time) * kmPerHourPerKnot;
		double distRatio = distance / radiusEarth;
		double distRatioSine = Math.sin(distRatio);
	    double distRatioCosine = Math.cos(distRatio);
	    double startLatRad = Math.toRadians(Latitude);
	    double startLonRad = Math.toRadians(Longitude);
	    double startLatCos = Math.cos(startLatRad);
	    double startLatSin = Math.sin(startLatRad);
	    double initialBearingRadians = Math.toRadians(initBearing);
	    double endLatRads = Math.asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.cos(initialBearingRadians)));
	    double endLonRads = startLonRad
		        + Math.atan2(Math.sin(initialBearingRadians) * distRatioSine * startLatCos,
		        		distRatioCosine - startLatSin * Math.sin(endLatRads));
	    futureCoord.setLat(Math.toDegrees(endLatRads));
	    futureCoord.setLon(Math.toDegrees(endLonRads));
	    
		return futureCoord;
	}
	
	public static double calcInitBearing(double lat1, double lat2, double lon1, double lon2){
		if(lat2 == 0)
			lat2 = 0.000000000001;
		if(lon2 == 0)
			lon2 = 0.000000000001;
		
		lat1 = Math.toRadians(lat1);
		lat2 = Math.toRadians(lat2);
		lon1 = Math.toRadians(lon1);
		lon2 = Math.toRadians(lon2);
		double bearing = Math.atan2((Math.sin(lon2 - lon1) * Math.cos(lat2)),
				(Math.cos(lat1) * Math.sin(lat2)) - (Math.sin(lat1) * Math.cos(lat2) * Math.cos(lon2 - lon1)));
		
		return (Math.toDegrees(bearing) + 360) % 360;
	}
	

	public static double calcFinalBearing(double lat1, double lat2, double lon1, double lon2){
		if(lat2 == 0)
			lat2 = 0.000000000001;
		if(lon2 == 0)
			lon2 = 0.000000000001;
		
		
		double bearing = calcInitBearing(lat2,lat1,lon2,lon1);
		return ((bearing + 180) % 360);
	}

}
