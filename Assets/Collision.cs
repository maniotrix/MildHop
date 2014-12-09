using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

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

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Cube") {
			//player_jump.Yspeed=0.0f;
			//transform.position=new Vector3(player_jump.Xposition,player_jump.Yposition,transform.position.z);
			demo.Yspeed=0;
			player_jump.start=false;
			player_jump.direction=true;
			transform.position = new Vector3(Xposition,Yposition,Zposition);
			player_jump.cam.position=player_jump.Cam_position;
			print("fefd");
		}
	}
	
	
	
	
	
	
}
