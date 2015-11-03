//Coordinate class
public class Coord {
	private double lat;
	private double alt;
	private double lon;
	
	public double getLat(){
		return lat;
	}
	
	public double getAlt(){
		return alt;
	}
	
	public double getLon(){
		return lon;
	}
	
	public void setLat(double Latitude){
		lat = Latitude;
	}
	
	public void setAlt(double Altitude){
		alt = Altitude;
	}
	
	public void setLon(double Longitude){
		lon = Longitude;
	}

}
