using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Canvas : MonoBehaviour {

	private float firstTime;

	// Use this for initialization
	void Start () {
		firstTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup - firstTime >= 5) {
			Image temp = gameObject.GetComponentInChildren<Image> ();
			gameObject.GetComponentInChildren <Image> ().enabled = false;
		}
	}
}
