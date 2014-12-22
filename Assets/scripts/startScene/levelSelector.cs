using UnityEngine;
using UnityEngine.WindowsPhone;
using System.Collections;
using System;

public class levelSelector : MonoBehaviour
{
    public Transform ref_c;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    var pointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                    transform.position = new Vector3(pointInWorld.x, ref_c.position.y, pointInWorld.z);
                }
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        finally
        {

        }
    }

    void OnGUI()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.name == "level1Cube")
                Application.LoadLevel("level1");
            else if (other.name == "level2Cube")
                Application.LoadLevel("level2");
            else if (other.name == "level3Cube")
                Application.LoadLevel("level3");
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }
}
