using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public float mSpeed = 1.0f;
	public float rSpeed = 1.0f;
	public int hitTime = 0;

	bool attacking = false;
	private GameObject myTank;
	private bool startBleed = false;
	private float bloodTime = 0.0f;

	// Use this for initialization
	void Start () {
		myTank = GameObject.Find ("tank");
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (transform.position, myTank.transform.position);

		Animator animator = GetComponent<Animator> ();
		animator.SetBool ("isAttacking", attacking);

		if (dist < 5.0f) {
			attacking = true;
			bloodTime += Time.deltaTime;
			if (!startBleed) {
				GameObject.Find ("Canvas").GetComponent<Canvas> ().GetComponent <CanvasController> ().blood -= 10;
				startBleed = true;
			}
			if (startBleed && bloodTime > 1.433) {
				GameObject.Find ("Canvas").GetComponent<Canvas> ().GetComponent <CanvasController> ().blood -= 10;
				bloodTime = 0;
			}
		} else {
			attacking = false;
		}

		Vector3 lookAt = new Vector3 ();
		lookAt = myTank.transform.position;
		Vector3 relative = transform.InverseTransformPoint (lookAt);

		float currAngle = Mathf.Atan2 (relative.x, relative.z) * Mathf.Rad2Deg;
		if (currAngle > 0)
			currAngle -= 180.0f;
		else
			currAngle += 180.0f;

//		Debug.Log (currAngle.ToString ());

		if (currAngle > 10 && currAngle < 180) {
			transform.Rotate (0, -rSpeed, 0);
		} 
		else if(currAngle < -10 && currAngle > -180) {
			transform.Rotate (0, rSpeed, 0);
		}

		transform.Translate (0.0f, 0.0f, mSpeed);


		if (hitTime >= 5) {
			Destroy (GameObject.Find ("zombie"));
		}
	}
}
