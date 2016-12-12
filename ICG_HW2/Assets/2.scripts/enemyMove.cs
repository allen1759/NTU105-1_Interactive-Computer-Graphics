using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {

	public float mSpeed = 1;
	public float rSpeed = 1;

	private bool isFindMe = false;
	private GameObject myTank;
	private float viewDistance = 30.0f;
	private float viewAngle = 60.0f;

	// Use this for initialization
	void Start () {
		myTank = GameObject.Find ("tank");
	}

	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (transform.position, myTank.transform.position);

		if (dist < viewDistance) {
			Vector3 lookAt = new Vector3 ();
			lookAt = myTank.transform.position;
			Vector3 relative = transform.InverseTransformPoint (lookAt);

			float currAngle = Mathf.Atan2 (relative.x, relative.z) * Mathf.Rad2Deg;
			if (currAngle > 0)
				currAngle -= 180.0f;
			else
				currAngle += 180.0f;
			
			if (3 < Mathf.Abs (currAngle) && Mathf.Abs (currAngle) < viewAngle) {
				if (currAngle > 0 && currAngle < 180) {
					transform.Rotate (0, -rSpeed, 0);
				} 
				else {
					transform.Rotate (0, rSpeed, 0);
				}
			}
		}
//		float h = Input.GetAxis ("Horizontal");
//		transform.Rotate(0,rSpeed * h,0);
//
//		transform.Translate(0,0,-mSpeed);
	}
}
