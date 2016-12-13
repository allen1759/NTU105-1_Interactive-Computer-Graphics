using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public float mSpeed = 1.0f;
	public float rSpeed = 1.0f;

	private GameObject myTank;

	// Use this for initialization
	void Start () {
		myTank = GameObject.Find ("tank");
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (transform.position, myTank.transform.position);

		Vector3 lookAt = new Vector3 ();
		lookAt = myTank.transform.position;
		Vector3 relative = transform.InverseTransformPoint (lookAt);

		float currAngle = Mathf.Atan2 (relative.x, relative.z) * Mathf.Rad2Deg;
		if (currAngle > 0)
			currAngle -= 180.0f;
		else
			currAngle += 180.0f;

		Debug.Log (currAngle.ToString ());

		if (currAngle > 5 && currAngle < 180) {
			transform.Rotate (0, -rSpeed, 0);
		} 
		else if(currAngle < -5 && currAngle > -180) {
			transform.Rotate (0, rSpeed, 0);
		}

		transform.Translate (0.0f, 0.0f, mSpeed);
	}
}
