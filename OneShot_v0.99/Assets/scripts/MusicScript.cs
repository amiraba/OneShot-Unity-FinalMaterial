using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicScript : MonoBehaviour {

	static bool AudioBegin = false; 
	void Awake()
	{
		if (!AudioBegin) {
			GetComponent<AudioSource>().Play ();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
		SceneManager.LoadScene ("menu");
	}
	void Update () {
		// Ken n7ebbou nbadlou el musique fi scene
//		if(Application.loadedLevelName == "Upgraded")
//		{
//			GetComponent<AudioSource>().Stop();
//			AudioBegin = false;
//		}
	}
}
