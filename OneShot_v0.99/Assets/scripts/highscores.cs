using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highscores : MonoBehaviour {

	public Text h1;
	public Text h2;
	public Text h3;
	public Text h4;
	public Text h5;

	// Use this for initialization
	void Start () {
		h1.text = GameController.highscores [0].ToString();
		h2.text = GameController.highscores [1].ToString();
		h3.text = GameController.highscores [2].ToString();
		h4.text = GameController.highscores [3].ToString();
		h5.text = GameController.highscores [4].ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enable()
	{
		gameObject.SetActive (true);
	}

	public void Disable()
	{
		GameObject.Find("Highscores").SetActive (false);
	}
}
