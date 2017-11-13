using UnityEngine;
using System.Collections;

public class ballscript : MonoBehaviour
{



    private Fire shoot;

    private bool boolplay = false;

    public Rigidbody kartoucha;

    public Transform barrelEnd;

    // Use this for initialization
    void Start()
    {

        shoot = GameObject.FindGameObjectWithTag("FireTag").GetComponent<Fire>();
    }

    // Update is called once per frame
	void Update()
	{
		YedController yed = GameObject.FindGameObjectWithTag("YedTag").GetComponent<YedController>();

		if ((!boolplay) && (shoot.ballshooted))
		{
			boolplay = true;
			Quaternion angles;
			Rigidbody rocketInstance;
			float angle = barrelEnd.rotation.z * Mathf.Rad2Deg;
			if (angle < 0f)
			{
				if (angle > -25f)
					angle += 11f;
				else
					angle -= 11f;
				angles = Quaternion.Euler(barrelEnd.transform.eulerAngles);
			}
			else
			{
				angle += 35f;
				angles = barrelEnd.rotation;
			}

			barrelEnd.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			rocketInstance = Instantiate(kartoucha, barrelEnd.position, angles) as Rigidbody;
			rocketInstance.AddForce(barrelEnd.right * 80);

		}
	}
}
