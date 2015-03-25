using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	public GameObject fixedStar;

	private PositionOfSatellite currentPosition;

	// Use this for initialization
	void Start () {
		this.currentPosition = calculateSelfAngle ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			setHorizontalAngle (gameObject, this.currentPosition.getHorizontalAngle());
		}

		int sign = 1;

		if (Input.GetKey (KeyCode.RightShift) || Input.GetKey (KeyCode.LeftShift)) {
			sign = -1;
		}

		if (Input.GetKey ("x")) {
			translate(Vector3.right * sign * 0.1f);
		}

		if (Input.GetKey ("y")) {
			translate(Vector3.up * sign * 0.1f);
		}

		if (Input.GetKey ("z")) {
			translate(Vector3.forward * sign * 0.1f);
		}

		if (Input.GetKey ("c")) {
			translateCircling(1.0f * sign);
			setHorizontalAngle (gameObject, this.currentPosition.getHorizontalAngle());
		}

	}

	private void translateCircling(float angle) {
		Vector3 previousPosition = transform.position;
		Vector3 distanceFromPreviousPosition = new Vector3 ();
		distanceFromPreviousPosition.x = fixedStar.transform.position.x - previousPosition.x;
		distanceFromPreviousPosition.z = fixedStar.transform.position.z - previousPosition.z;

		this.currentPosition.increaseHorizontalAngle (angle);

		float currentAngle = this.currentPosition.getHorizontalAngle ();


		Vector3 distanceToTheStar = new Vector3 ();

		distanceToTheStar.x = 
			this.currentPosition.getDistance() * 
				Mathf.Cos (currentAngle * Mathf.Deg2Rad);

		distanceToTheStar.z = 
				this.currentPosition.getDistance() * 
				Mathf.Sin (currentAngle * Mathf.Deg2Rad);

		float tmpY = transform.localPosition.y;
		Vector3 tmpPos = fixedStar.transform.position - distanceToTheStar;
		transform.localPosition = new Vector3 (tmpPos.x, tmpY, tmpPos.z);
	}

	private void translate(Vector3 distance) {
		transform.Translate(distance);
		this.currentPosition = calculateSelfAngle ();
//Debug.Log ("Angle: " + this.currentPosition.getAngle ());

	}

	private PositionOfSatellite calculateSelfAngle() {
		return calculateAngleBetween (gameObject, fixedStar);
	}

	private static PositionOfSatellite calculateAngleBetween(GameObject target, GameObject fixedObject) {
		Vector3 distance = fixedObject.transform.position - target.transform.position;
		
		float horizontalAngle = Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg;
		if (distance.x < 0.0f) {
			horizontalAngle += 180.0f;
		} else if (distance.y < 0.0f) {
			horizontalAngle += 360.0f;
		}

		return new PositionOfSatellite (
			horizontalAngle, 0.0f, Mathf.Sqrt(Mathf.Pow(distance.z, 2) + Mathf.Pow(distance.x, 2)));
	}

	private static void setHorizontalAngle(GameObject target, float angle) {
		target.transform.Rotate (new Vector3 (0.0f, (450.0f - angle) % 360.0f - target.transform.localEulerAngles.y, 0.0f));
	}

//	private void focusOnTheStarOnRelativeX () {
	//	}
}
