using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bacteria_trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
		Destroy (this.gameObject);
		ScoreManager scoreManager = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager> ();
		scoreManager.StopScore = true;
		GameController.TotalScore += scoreManager.CurrentScore;
		GameController.LevelScore = scoreManager.CurrentScore;
		SceneManager.LoadScene ("NextLevelMenu");
	}


}
