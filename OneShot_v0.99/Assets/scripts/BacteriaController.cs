using UnityEngine;
using System.Collections;

public class BacteriaController : MonoBehaviour {



	public Vector3 pointB;

	IEnumerator Start()
	{
		var pointA = transform.position;
		pointB = new Vector3 (transform.position.x, transform.position.y+7, transform.position.z);
		while (true) {
			float speed = Random.Range (0.5f,1.5f);
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, speed));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, speed));
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
}
