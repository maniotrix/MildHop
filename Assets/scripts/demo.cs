using UnityEngine;
using System.Collections;

public class demo : MonoBehaviour {

	public static float Yspeed=0.04f;
	public static float Yposition=0.0f;
	public static float Xposition=0.0f;
	public static float Zposition=0.0f;
	// Use this for initialization
	void Start ()
	{
		Yposition = transform.position.y;
		Xposition = transform.position.x;
		Zposition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
    {
		transform.Translate (Yspeed, 0,0);
	}

}
