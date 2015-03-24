public class PositionOfSatellite {

	private float angle;
	private float distance;

	public PositionOfSatellite(float angle, float distance) {
		set (angle, distance);
	}

	public void set(float angle, float distance) {
		this.angle = angle;
		this.distance = distance;
	}

	public float getAngle() {
		return this.angle;
	}

	public float getDistance() {
		return this.distance;
	}

}
