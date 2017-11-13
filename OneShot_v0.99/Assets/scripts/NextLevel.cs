using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickNextLevel() {
		int nextLevel = ++GameController.CurrentLevel;
		string nextLevelName = "level" + nextLevel;
		UnityEngine.SceneManagement.SceneManager.LoadScene (nextLevelName);
	}
}
