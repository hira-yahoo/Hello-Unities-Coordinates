﻿using UnityEngine;
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
		currentAngle = transform.rotation.y;
		calclateSelfAngle ();
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
		calclateSelfAngle ();
	}

	private void calclateSelfAngle() {
		this.currentAngle = calculateAngleBetween (gameObject, fixedStar);
	}

	private static float calculateAngleBetween(GameObject target, GameObject fixedObject) {
		Vector3 distance = fixedObject.transform.position - target.transform.position;
		
		float angle = Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg;
		if (distance.x < 0.0f) {
			angle += 180.0f;
		} else if (distance.y < 0.0f) {
			angle += 360.0f;
		}

		return angle;
	}

	private void focusOnTheStar() {
		
		focusOnYOn (gameObject, fixedStar);
		//		focusOnTheStarOnRelativeX ();
	}
	
	private void focusOnYOn(GameObject target, GameObject fixedObject) {
		setAngle (target, this.currentAngle);

//		Debug.Log ("y: " + (transform.localEulerAngles.y));

//		Debug.Log ("x: " + distance.x + ", y: " + distance.y + ", z: " + distance.z + ", tan:" + Mathf.Atan (distance.z / distance.x) * Mathf.Rad2Deg + 
//		           ", degree:" + degree + ", subtructed:" + ((450.0f - degree) % 360.0f));

	}

	private static void setAngle(GameObject target, float angle) {
		target.transform.Rotate (new Vector3 (0.0f, (450.0f - angle) % 360.0f - target.transform.localEulerAngles.y, 0.0f));
	}

//	private void focusOnTheStarOnRelativeX () {
	//	}
}
