using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float ballInitialVelocity = 80f;


    private bool ballInPlay;
    public GameObject ballempty;
    private DexterController dexterScript;
    private bool ballshooted = false;



    void Start()
    {
        if (!ballshooted)
        {
            ballshooted = true;
            //dexterScript = GameObject.FindGameObjectWithTag ("dexterTag").GetComponent<DexterController> ();
            //var spawn_ball = new Vector2 (dexterScript.transform.position.x + 2, dexterScript.transform.position.y + 1);
            //Instantiate (ballempty, spawn_ball, transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

}