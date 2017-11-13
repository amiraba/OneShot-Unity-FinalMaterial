using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{


    public bool ballshooted = false;

    public void go()
    {
        if (!ballshooted)
        {
            ballshooted = true;
        }

    }

    void awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}