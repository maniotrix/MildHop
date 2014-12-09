using UnityEngine;
using System.Collections;

public class player_jump : MonoBehaviour
{
	public Transform object0;
	public Transform object1;
	public Transform ref_p;
	public Transform main_cam;
	public static Transform cam;
	public static float Yposition=0.0f;
	public static float Xposition=0.0f;
	public static float Zposition=0.0f;
	float distance =0;
	public static bool direction=true;
	public static bool start=false;
	public static Vector3 Cam_position;
	Vector3 player_position ;
	private Vector2 fp;  // first finger position
	private Vector2 lp;  // last finger position


	// Use this for initialization
	void Start ()
	{	cam = main_cam;
		player_along_z.speed = 0.0f;
		Yposition = transform.position.y;
		Xposition = transform.position.x;
		Zposition = transform.position.z;
		distance = Vector3.Distance (object0.position, object1.position);
		Cam_position = cam.position;
		player_position = new Vector3 (Xposition, Yposition, Zposition);
	}

	// Update is called once per frame
	void Update ()
	{	//print("y= "+transform.position.y);
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}
			if (touch.phase == TouchPhase.Moved )
			{
				lp = touch.position;
			}
			if(touch.phase == TouchPhase.Ended)
			{ 
				
				if((fp.x - lp.x) > 80) // left swipe
				{
					

					
				}
				else if((fp.x - lp.x) < -80) // right swipe
				{
					transform.position=new Vector3(transform.position.x+distance,
					                               transform.position.y,
					                               transform.position.z);
					
					
					direction=!direction;
					start=true;
				}
				else if((fp.y - lp.y) < -80 ) // up swipe
				{
					// add your jumping code here
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) ){
			transform.position=new Vector3(transform.position.x+distance,
			                               transform.position.y,
			                               transform.position.z);


			direction=!direction;
			start=true;
		}
		if (start == false) {
			transform.Translate (0, 0, player_along_z.speed);

		}
		if(direction==false && start==true){
			transform.Translate (0,0, Move_along_z.speed);
			print (direction);
		}
		
		if(direction==true && start==true){
			transform.Translate (0,0, Move_along_z2.speed);
			print (direction);
		}

		if(Vector3.Distance(transform.position , new Vector3 (Xposition, Yposition, Zposition) ) > 5*distance){
			player_position = transform.position;
			//cam.position=new Vector3((Cam_position.x+3*distance),Cam_position.y,Cam_position.z);
			cam.Translate(0.01f,0,0);
		}
		if (Mathf.Abs (transform.position.z) > ref_p.position.z || Vector3
		     			.Distance(transform.position , new Vector3 (Xposition, Yposition, Zposition) ) > 14*distance ) {
			player_jump.start=false;
			player_jump.direction=true;
			transform.position = new Vector3(Xposition,Yposition,Zposition);
			cam.position=Cam_position;
		}

	}


}


