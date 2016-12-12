using UnityEngine;
using System.Collections;

public class CameraSelector : MonoBehaviour {

	private float CameraRotateSpeed = 3.0f;
	private float thirdAngle = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Alpha1)) {
			transform.localPosition = new Vector3(0.0f, 1.088f, 2.1199f);
			transform.localRotation = Quaternion.Euler(11.96f, 180.0f, 0.0f);
		}
		else if (Input.GetKey(KeyCode.Alpha2)) {
			transform.localPosition = new Vector3(0.0f, 0.45f, -0.4f);
			transform.localRotation = Quaternion.Euler(11.96f, 180.0f, 0.0f);
		}
		else if (Input.GetKey(KeyCode.Alpha3)) {
			//transform.localPosition = new Vector3(0.0f, 1.15f, -2.0f);
			UpdateAngle ();
		}

		// for third person view
		if (Input.GetKey (KeyCode.R)) {
//			transform.RotateAround (transform.parent.position, new Vector3 (0.0f, 1.0f, 0.0f), CameraRotateSpeed);
			thirdAngle += 2.0f;
			UpdateAngle ();
		}
		else if (Input.GetKey (KeyCode.T)) {
//			transform.RotateAround (transform.parent.position, new Vector3 (0.0f, -1.0f, 0.0f), CameraRotateSpeed);
			thirdAngle -= 2.0f;
			UpdateAngle ();
		}
	}

	private void UpdateAngle () {
		transform.localRotation = Quaternion.Euler (11.96f, 270.0f-thirdAngle, 0.0f);
		transform.localPosition = new Vector3 (3.0f * Mathf.Cos (Mathf.PI * thirdAngle / 180.0f),
			1.0f,
			3.0f * Mathf.Sin (Mathf.PI * thirdAngle / 180.0f));
	}
}
