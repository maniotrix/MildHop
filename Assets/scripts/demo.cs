using UnityEngine;
using System.Collections;
using System;

public class demo : MonoBehaviour 
{
	public static float Yspeed=0.04f;
	public static float Yposition=0.0f;
	public static float Xposition=0.0f;
	public static float Zposition=0.0f;
	// Use this for initialization
	void Start ()
	{
        try
        {
            Yposition = transform.position.y;
            Xposition = transform.position.x;
            Zposition = transform.position.z;
        }
        catch(Exception e)
        {
            print(e.Message);
        }
	}
    
	
	// Update is called once per frame
	void Update () 
    {
        try
        {
            transform.Translate(Yspeed, 0, 0);
        }
        catch (Exception e)
        {
            print(e.Message);
        }
	}

}
