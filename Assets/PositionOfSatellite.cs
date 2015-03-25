public class PositionOfSatellite {

	private float horizontalAngle;
	private float distance;

	public PositionOfSatellite(float horizontalAngle, float distance) {
		this.horizontalAngle = horizontalAngle;
		setDistance (distance);
	}

	public float getHorizontalAngle() {
		return this.horizontalAngle;
	}

	public void increaseHorizontalAngle(float angle) {
		this.horizontalAngle += angle;
	}

	public void setDistance(float distance) {
		this.distance = distance;
	}

	public float getDistance() {
		return this.distance;
	}



}
