using UnityEngine;
using System.Collections;

public class HoG_handled : MonoBehaviour {

	public GameObject EoG;

	public bool[] faceCreated;
	private bool allFaceCreated = false;

	// Use this for initialization
	void Start () {
		faceCreated = new bool[] {false,false,false,false};
	}
	
	// Update is called once per frame
	void Update () {
		if (allFaceCreated) {
			//EoG.GetComponent<TrackingAction> ().enabled = true;
			faceCreated [0] = false;
			allFaceCreated = false;
		}
		else if (faceCreated [0] && faceCreated [1] && faceCreated [2] && faceCreated [3])
			allFaceCreated = true;
	}
}
