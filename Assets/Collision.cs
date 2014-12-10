using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour 
{

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

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name == "Cube") 
        {
			demo.Yspeed=0;
            playerJump.direction = playerJump.STATE_OF_OBJECT.AT_START;
			transform.position = new Vector3(Xposition,Yposition,Zposition);
			playerJump.startCam.position=playerJump.Cam_position;
			print("fefd");
		}
	}
	
	
	
	
	
	
}
