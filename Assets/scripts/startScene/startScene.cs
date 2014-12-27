using UnityEngine;
using System;

public class startScene : MonoBehaviour
{
    public Transform ref_c;
    
    void Awake()
    {
        Application.targetFrameRate = -1;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    var pointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                    transform.position = new Vector3(pointInWorld.x, ref_c.position.y, pointInWorld.z);
                }
            }
        }
        catch(Exception e)
        {
            print(e.Message);
        }
        finally
        {

        }
    }

    void OnGUI()
    {
        //GUI.Box(new Rect(0.25f * Screen.width, 0.25f * Screen.height, 0.5f * Screen.width, 0.5f * Screen.height), "\n\ncolliding"); 
    }

    void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.name == "playCube")
            {
                Application.LoadLevel("2levelSelector");
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }
}
