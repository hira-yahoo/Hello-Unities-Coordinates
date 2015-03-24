public class PositionOfSatellite {

	private float angle;
	private float distance;

	public PositionOfSatellite(float angle, float distance) {
		setAngle (angle);
		setDistance (distance);
	}

	public void setAngle(float angle) {
		this.angle = angle;
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
