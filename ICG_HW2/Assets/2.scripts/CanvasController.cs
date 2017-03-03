using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasController : MonoBehaviour {

	public int blood = 500;
	private float firstTime;

	// Use this for initialization
	void Start () {
		firstTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		transform.FindChild ("Blood").gameObject.GetComponent<Image> ().rectTransform.sizeDelta = new Vector2 (blood, 40);

		if (Time.realtimeSinceStartup - firstTime >= 5) {
//			Image temp = gameObject.GetComponentInChildren<Image> ();
			transform.FindChild ("Background").gameObject.GetComponent<Image> ().enabled = false;
		}
	}
}
