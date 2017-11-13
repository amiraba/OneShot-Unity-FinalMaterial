using UnityEngine;
using System.Collections;

public class last : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Music").GetComponent<AudioSource> ().Pause ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
