using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreWellDone : MonoBehaviour {

	public Text LevelScore ;

	public Text TotalScore ;

	// Use this for initialization
	void Start () {
		LevelScore.text = "Level Score: " + System.Convert.ToInt32(GameController.LevelScore);
		TotalScore.text = "Total Score: " + System.Convert.ToInt32(GameController.TotalScore);
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void Exit()
	{
		GameController.CurrentLevel = 0;
		GameController.TotalScore = 0;
		Time.timeScale = 1;	
		GameObject.Find ("Music").GetComponent<AudioSource> ().UnPause();
		SceneManager.LoadScene ("menu");
	}
}
