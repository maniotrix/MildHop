using UnityEngine;
using System.Collections;
using System;

public class player_along_z : MonoBehaviour 
{
    public static float speed;

	// Use this for initialization
	void Start () 
    {
        speed = 0.06f * Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () 
    {
        try
        {
            if (Time.timeScale == 1)
            {
                transform.Translate(speed, 0, 0);
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
	}


}
