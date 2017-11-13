using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class GameOverScore : MonoBehaviour {

	public Text LevelScore ;

	public Text TotalScore ;

	// Use this for initialization
	void Start () {

		GameController.LevelScore = 0;
		LevelScore.text = "Level Score:" + Convert.ToInt32(GameController.LevelScore);
		TotalScore.text = "Total Score:" + Convert.ToInt32(GameController.TotalScore);
		GameController.highscores.Add (Convert.ToInt32 (GameController.TotalScore));
		GameController.highscores.Sort ((a,b) => -1* a.CompareTo(b));
		GameController.TotalScore = 0;
		int i = 0;
		foreach (var item in GameController.highscores) {
			i++;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
