using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class loadlevel : MonoBehaviour {

	public void play()  {
//		Application.LoadLevel ("map");
		SceneManager.LoadScene("level1");

	}

	public void exit() {
		string s;
		for (int i = 0; i < 5; i++) {
			s = "h" + i;
			PlayerPrefs.SetInt (s, GameController.highscores [i]);
		}		
		PlayerPrefs.Save ();
		Application.Quit();
	}

	public void main(){
		SceneManager.LoadScene("menu");
	}

	public void credits(){
		SceneManager.LoadScene("scene");
	}

	public void PlayTuto(){
		Handheld.PlayFullScreenMovie ("Tuto1080.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		SceneManager.LoadScene("level1");
	}

}
