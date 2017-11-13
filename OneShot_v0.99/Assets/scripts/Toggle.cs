using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Toggle : MonoBehaviour {


	public Text message;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Toggles", 0, 1.5f);

	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator ToggleObject() {

		gameObject.SetActive (!gameObject.activeSelf);
		yield return new WaitForSeconds(2);

	}

	void Toggles() {
		if (message.text == "")
			message.text = "Tap anywhere to skip";
		else
			message.text = "";
	}
}
