using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	public GameObject fixedStar;

	// Use this for initialization
	void Start () {
	
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
			transform.Translate(Vector3.right * sign * 0.1f);
		}

		if (Input.GetKey ("z")) {
			transform.Translate(Vector3.forward * sign * 0.1f);
		}
	}

	private void focusOnTheStar() {

		focusOnTheStarOnY ();
//		focusOnTheStarOnRelativeX ();
	}

	private void focusOnTheStarOnY() {
		Vector3 distance = fixedStar.transform.position - gameObject.transform.position;

		float degree = Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg;
		if (distance.x < 0.0f) {
			degree += 180.0f;
		} else if (distance.y < 0.0f) {
			degree += 360.0f;
		}

//		Debug.Log ("y: " + (transform.localEulerAngles.y));
		transform.Rotate (new Vector3 (0.0f, (450.0f - degree) % 360.0f - transform.localEulerAngles.y, 0.0f));

//		Debug.Log ("x: " + distance.x + ", y: " + distance.y + ", z: " + distance.z + ", tan:" + Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg + 
//		           ", degree:" + degree + ", subtructed:" + ((450.0f - degree) % 360.0f));

	}

//	private void focusOnTheStarOnRelativeX () {
	//	}
}
