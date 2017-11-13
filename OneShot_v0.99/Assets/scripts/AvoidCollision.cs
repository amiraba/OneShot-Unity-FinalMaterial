using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AvoidCollision : MonoBehaviour {

	public AudioSource wallSound;

	public AudioSource redSound;


	// Use this for initialization
	void Start () {

		Collider yedCollider = GameObject.FindGameObjectWithTag ("YedTag").GetComponent<Collider> ();
		Physics.IgnoreCollision (GetComponent<Collider>(), yedCollider);
	}
	void OnCollisionEnter (Collision other) {
		switch (other.gameObject.tag) {
		case "WallTag":
			wallSound.Play();
		break;
		case "MalusTag":
			redSound.Play ();
			GameController.nbMalus++;
			break;

		default:
			break;
		}
	}


	void PlaySound(AudioClip audio)
	{
		GetComponent<AudioSource>().clip = audio;
		GetComponent<AudioSource>().Play ();
	}


}
