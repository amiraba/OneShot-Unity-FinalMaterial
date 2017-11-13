using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static int CurrentLevel = 0;

	public static float LevelScore;

	public static float TotalScore = 0;

	public static int nbBonus = 0;

	public static int nbMalus = 0;

	public static AudioSource greenSound;

	public static List<int> highscores;

	void Start ()
	{
		greenSound = GetComponent<AudioSource> ();
		highscores = new List<int>();
		string s;
		for (int i = 1; i < 6; i++) {
			s = "h" + i;
			highscores.Add (PlayerPrefs.GetInt (s));

		}
			

	}

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
