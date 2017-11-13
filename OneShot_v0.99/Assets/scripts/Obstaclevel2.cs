using UnityEngine;
using System.Collections;

public class Obstaclevel2 : MonoBehaviour {


	public Sprite sprite1;

	public Sprite sprite2;


	public Vector3 pointB;

	IEnumerator Start()
	{
		var pointA = transform.position;
		pointB = new Vector3 (transform.position.x, transform.position.y+4.5f, transform.position.z);
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	IEnumerator OnTriggerEnter(Collider other) {
		GameController.greenSound.Play ();
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprite2;
		yield return new WaitForSeconds (0.5f);
		spriteRenderer.sprite = sprite1;
		Destroy(gameObject);
		GameController.nbBonus ++;

	}


}
