using UnityEngine;
using System.Collections;
using System;

public class HighscoresWellDone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameController.highscores.Add (Convert.ToInt32 (GameController.TotalScore));
		GameController.highscores.Sort ((a,b) => -1* a.CompareTo(b));
		int i = 0;
		foreach (var item in GameController.highscores) {
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
