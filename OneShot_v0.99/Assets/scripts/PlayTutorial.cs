using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class PlayTutorial : MonoBehaviour {


	public AudioSource audios;

	// Use this for initialization
	void Start () {

		Handheld.PlayFullScreenMovie ("Tuto1080.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject.Find ("Music").GetComponent<AudioSource> ().UnPause ();
			SceneManager.LoadScene ("level1");
		}
		StartCoroutine(Wait());

	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(53);
		GameObject.Find ("Music").GetComponent<AudioSource> ().UnPause ();
		SceneManager.LoadScene ("level1");
	}


}
