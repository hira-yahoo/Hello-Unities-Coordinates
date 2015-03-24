public class PositionOfSatellite {

	private float angle;
	private float distance;

	public PositionOfSatellite(float angle, float distance) {
		this.angle = angle;
		setDistance (distance);
	}

	public float getAngle() {
		return this.angle;
	}

	public void setDistance(float distance) {
		this.distance = distance;
	}

	public float getDistance() {
		return this.distance;
	}



}
