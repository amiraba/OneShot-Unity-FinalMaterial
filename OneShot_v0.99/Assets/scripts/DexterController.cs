using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DexterController : MonoBehaviour {

	public Camera cam ;

	private float maxWidth;



	public Fire buttonFireScript;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		buttonFireScript = GameObject.FindGameObjectWithTag ("FireTag").GetComponent<Fire> ();


		if (cam == null) cam = Camera.main;
		Vector3 upperRighrCorner = new Vector3 (Screen.width,Screen.height,0.0f);
		Vector3 maxWidthV3 = cam.ScreenToWorldPoint (upperRighrCorner);
		float ballWidth = GetComponent<Renderer>().bounds.extents.y;
		maxWidth = maxWidthV3.y - ballWidth;
		string name = Application.loadedLevelName.ToString().Substring(5,1);
		GameController.CurrentLevel = System.Convert.ToInt32(name);
	}

	// Update is called once per frame
	void Update () {



		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit ;
		if(Physics.Raycast(ray,out hit)){
			if(hit.collider.tag == "dexterTag" && !buttonFireScript.ballshooted){
				Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
				Vector3 targetPosition = new Vector3 (0.0f, Mathf.Clamp(rawPosition.y,(float)-5,(float)3.5), 0.0f);
				float targetY = Mathf.Clamp (-maxWidth, targetPosition.y, maxWidth);
				targetPosition.y = targetY;
				GetComponent<Rigidbody> ().MovePosition (targetPosition);

			    }
		}

		

	}
}
