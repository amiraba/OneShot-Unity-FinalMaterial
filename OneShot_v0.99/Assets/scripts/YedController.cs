using UnityEngine;
using System.Collections;

public class YedController : MonoBehaviour
{

    public Fire buttonFireScript;

    void Start()
    {

        buttonFireScript = GameObject.FindGameObjectWithTag("FireTag").GetComponent<Fire>();


    }

    public Transform target;
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "YedTag" && !buttonFireScript.ballshooted)
            {
                Vector3 mouse_pos;
                Vector3 object_pos;
                float angle;
                mouse_pos = Input.mousePosition;
                mouse_pos.z = 5.23f; //The distance between the camera and object
                object_pos = Camera.main.WorldToScreenPoint(target.position);
                mouse_pos.x = mouse_pos.x - object_pos.x;
                mouse_pos.y = mouse_pos.y - object_pos.y;
                angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, -80, 20)));
            }
        }
    }
}