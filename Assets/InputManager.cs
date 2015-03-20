using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		int sign = 1;
		Vector3 vec3 = new Vector3 ();

		if (Input.GetKey (KeyCode.RightShift) || Input.GetKey (KeyCode.LeftShift)) {
			sign = -1;
		}

		if (Input.GetKey (KeyCode.X)) {
			vec3.x = 0.1f;
		}

		if (Input.GetKey (KeyCode.Y)) {
			vec3.y = 0.1f;
		}

		if (Input.GetKey (KeyCode.Z)) {
			vec3.z = 0.1f;
		}

		if (Input.GetKey (KeyCode.Backslash)) {
			rorateWithRotate(sign, vec3);
		} else {
//			translateWithTranslate(sign, vec3);
			translateWithTranslateAndConstants(sign, vec3);
		}

	}

	private void rorateWithRotate(int sign, Vector3 vec3) {
		float revision = 10.0f;
		cube.GetComponent<Transform>().Rotate(new Vector3(vec3.x * sign * revision, vec3.y * sign * revision, vec3.z * sign * revision));
	}

	private void translateWithTranslate(int sign, Vector3 vec3) {
		cube.GetComponent<Transform>().Translate(new Vector3(vec3.x * sign, vec3.y * sign, vec3.z * sign));
	}

	private void translateWithTranslateAndConstants(int sign, Vector3 vec3) {
		Vector3 constant = Vector3.zero, transition = vec3 * sign;
		float distance = 0.0f;
		if (transition.x > 0.0f) {
			constant = Vector3.right;
			distance = transition.x;
		}
		else if (transition.x < 0.0f) {
			constant = Vector3.left;
			distance = -transition.x;
		}
		else if (transition.y > 0.0f) {
			constant = Vector3.up;
			distance = transition.y;
		}
		else if (transition.y < 0.0f) {
			constant = Vector3.down;
			distance = -transition.y;
		}
		else if (transition.z > 0.0f) {
			constant = Vector3.forward;
			distance = transition.z;
		}
		else if (transition.z < 0.0f) {
			constant = Vector3.back;
			distance = -transition.z;
		}
		
		cube.GetComponent<Transform>().Translate(constant * distance);
	}
}
