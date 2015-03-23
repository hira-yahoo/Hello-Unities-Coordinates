public class PositionOfSatellite {

	private float angle;
	private float distance;

	PositionOfSatellite() {
		set (0.0f, 0.0f);
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
