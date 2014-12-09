using UnityEngine;
using System.Collections;

public class player_collision : MonoBehaviour {
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Cube") {
			//player_jump.Yspeed=0.0f;
			//transform.position=new Vector3(player_jump.Xposition,player_jump.Yposition,transform.position.z);
			
			transform.position = new Vector3(player_jump.Xposition,player_jump.Yposition,player_jump.Zposition);
			print("fefd");
		}
	}
	
	
	
	
	
	
}
