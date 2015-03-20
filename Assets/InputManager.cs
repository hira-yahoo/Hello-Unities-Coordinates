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
		float x = 0.0f, y = 0.0f, z = 0.0f;

		if (Input.GetKey (KeyCode.RightShift) || Input.GetKey (KeyCode.LeftShift)) {
			sign = -1;
		}

		if (Input.GetKey (KeyCode.X)) {
			x = 0.1f;
		}

		if (Input.GetKey (KeyCode.Y)) {
			y = 0.1f;
		}

		if (Input.GetKey (KeyCode.Z)) {
			z = 0.1f;
		}

		if (Input.GetKey (KeyCode.Backslash)) {
			float revision = 5.0f;
			cube.GetComponent<Transform>().Rotate(new Vector3(x * sign * revision, y * sign * revision, z * sign * revision));
		} else {
			cube.GetComponent<Transform>().Translate(new Vector3(x * sign, y * sign, z * sign));
		}

	}
}
