using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyMove : MonoBehaviour {

	public float mSpeed = 1.0f;
	public float rSpeed = 1.0f;

	private bool shouldFindMe = true;
	private GameObject myTank;
	private float viewDistance = 30.0f, fireDistance = 15.0f;
	private float viewAngle = 60.0f;

	private int patrolIndex = 1;
	private List<Vector3> patrolPoints;

	// Use this for initialization
	void Start () {
		myTank = GameObject.Find ("tank");

		patrolPoints = new List<Vector3> ();
		patrolPoints.Add (new Vector3 (110.3757f, 2.03134f, 30.4714f));
		patrolPoints.Add (new Vector3 (66.16527f, 1.784366f, 93.18163f));
		patrolPoints.Add (new Vector3 (44.204f, 1.862078f, 36.60983f));
		patrolPoints.Add (new Vector3 (78.1f, 2.030692f, 47.70478f));
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O))
			shouldFindMe = true;
		if (Input.GetKey (KeyCode.P))
			shouldFindMe = false;

		float dist = Vector3.Distance (transform.position, myTank.transform.position);

		bool shouldPatrol = true;

		if (dist < viewDistance && shouldFindMe) {
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

				if (dist > fireDistance) {
					transform.Translate (0.0f, 0.0f, -mSpeed);
				}

				shouldPatrol = false;
			}
		}

		if (shouldPatrol) {
			Vector3 relative = transform.InverseTransformPoint (patrolPoints[patrolIndex]);

			float currAngle = Mathf.Atan2 (relative.x, relative.z) * Mathf.Rad2Deg;
			if (currAngle > 0)
				currAngle -= 180.0f;
			else
				currAngle += 180.0f;
			
			if (currAngle > 10 && currAngle < 180) {
				transform.Rotate (0, -rSpeed*5, 0);
			} 
			else if (currAngle < -10 && currAngle > -180) {
				transform.Rotate (0, rSpeed*5, 0);
			}
			else {
				transform.Translate (0.0f, 0.0f, -mSpeed * 5);
			}

			if (Vector3.Distance (patrolPoints [patrolIndex], transform.position) < 5.0f) {
				patrolIndex = (patrolIndex + 1) % patrolPoints.Count;
			}
		}
	}
}
