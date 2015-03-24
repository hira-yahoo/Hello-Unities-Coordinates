using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	public GameObject fixedStar;

	private PositionOfSatellite currentAngle;

	// Use this for initialization
	void Start () {
		this.currentAngle = calculateSelfAngle ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			setAngle (gameObject, this.currentAngle.getAngle());
		}

		int sign = 1;

		if (Input.GetKey (KeyCode.RightShift) || Input.GetKey (KeyCode.LeftShift)) {
			sign = -1;
		}

		if (Input.GetKey ("x")) {
			translate(Vector3.right * sign * 0.1f);
		}

		if (Input.GetKey ("z")) {
			translate(Vector3.forward * sign * 0.1f);
		}

		if (Input.GetKey ("c")) {
			//translateWithAngle()
			//transform.Translate(Vector3.forward * sign * 0.1f);
		}

	}

	private void translate(Vector3 distance) {
		transform.Translate(distance);
		this.currentAngle = calculateSelfAngle ();
	}

	private PositionOfSatellite calculateSelfAngle() {
		return calculateAngleBetween (gameObject, fixedStar);
	}

	private static PositionOfSatellite calculateAngleBetween(GameObject target, GameObject fixedObject) {
		Vector3 distance = fixedObject.transform.position - target.transform.position;
		
		float angle = Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg;
		if (distance.x < 0.0f) {
			angle += 180.0f;
		} else if (distance.y < 0.0f) {
			angle += 360.0f;
		}

		return new PositionOfSatellite (
			angle, Mathf.Sqrt(Mathf.Pow(distance.z, 2) + Mathf.Pow(distance.x, 2)));
	}

	private static void setAngle(GameObject target, float angle) {
		target.transform.Rotate (new Vector3 (0.0f, (450.0f - angle) % 360.0f - target.transform.localEulerAngles.y, 0.0f));
	}

//	private void focusOnTheStarOnRelativeX () {
	//	}
}
