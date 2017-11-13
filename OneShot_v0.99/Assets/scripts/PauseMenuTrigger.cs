using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuTrigger : MonoBehaviour {

	public GameObject PauseMenu ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPause () {

		Time.timeScale = 0;	
		PauseMenu.SetActive (true);
	}

	public void OnClickResume() {
		Time.timeScale = 1;	
		PauseMenu.SetActive (false);
	}

	public void OnClickReplay() {

		GameController.CurrentLevel = 0;
		Time.timeScale = 1;	
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	public void OnClickExit() {

		GameController.CurrentLevel = 0;
		GameController.TotalScore = 0;
		Time.timeScale = 1;	
		SceneManager.LoadScene ("menu");

	}

	public void OnClickNextLevel() {


	}
}
