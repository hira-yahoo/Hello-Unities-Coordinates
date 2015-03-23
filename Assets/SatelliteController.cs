using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	public GameObject fixedStar;

	private Vector3 initialPosition;
	private Vector3 fixedPosition;
	private float currentAngle;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		fixedPosition = fixedStar.transform.position;
		currentAngle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKey ("f")) {
			if (Input.GetKeyDown ("f")) {
				focusOnTheStar ();
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
	}

	private void focusOnTheStar() {

		focusOnYOn (gameObject, fixedStar);
//		focusOnTheStarOnRelativeX ();
	}

	private static void focusOnYOn(GameObject target, GameObject fixedObject) {
		Vector3 distance = fixedObject.transform.position - target.transform.position;

		float degree = Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg;
		if (distance.x < 0.0f) {
			degree += 180.0f;
		} else if (distance.y < 0.0f) {
			degree += 360.0f;
		}

//		Debug.Log ("y: " + (transform.localEulerAngles.y));
		target.transform.Rotate (new Vector3 (0.0f, (450.0f - degree) % 360.0f - target.transform.localEulerAngles.y, 0.0f));

//		Debug.Log ("x: " + distance.x + ", y: " + distance.y + ", z: " + distance.z + ", tan:" + Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg + 
//		           ", degree:" + degree + ", subtructed:" + ((450.0f - degree) % 360.0f));

	}

//	private void focusOnTheStarOnRelativeX () {
	//	}
}
