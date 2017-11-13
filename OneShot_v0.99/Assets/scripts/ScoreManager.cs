using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;

	public float CurrentScore;

	public float PointsPerSecond;

	public bool StopScore = false;

	// Update is called once per frame
	void Update () {



		if (!StopScore) {
			
			CurrentScore = Mathf.Max(CurrentScore - (PointsPerSecond * Time.deltaTime) + (GameController.nbBonus * 100) - (GameController.nbMalus * 50),0);
			ScoreText.text = "Score: " + System.Convert.ToInt32 (CurrentScore);

		}
		if (GameController.nbBonus != 0) {
			GameController.nbBonus = 0;
		}	
		if (GameController.nbMalus != 0) {
			GameController.nbMalus = 0;
		}
		if (CurrentScore == 0) {
			SceneManager.LoadScene ("GameOverMenu");
		}
	}
}
