using UnityEngine;
using System.Collections;

public class player_jump : MonoBehaviour
{
    public enum STATE_OF_OBJECT
    {
        AT_START,
        LEFT,
        RIGHT
    } ;

    public Transform object0;
	public Transform object1;
	public Transform ref_p;
	public Transform main_cam;
	public static Transform cam;
	public static float Yposition=0.0f;
	public static float Xposition=0.0f;
	public static float Zposition=0.0f;
    float distance;                                     //  Distance between ______
    public static STATE_OF_OBJECT direction;            //  State of object
	public static Vector3 Cam_position;
	Vector3 player_position ;
	private Vector2 fp;  // first finger position
	private Vector2 lp;  // last finger position


	// Use this for initialization
	void Start ()
	{
        direction = STATE_OF_OBJECT.AT_START;
        distance = 0.0f;
        cam = main_cam;
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
	{	
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
                    moveForward();
                    //transform.position=new Vector3(transform.position.x+distance,
                    //                               transform.position.y,
                    //                               transform.position.z);
					
					
                    //direction=!direction;
                    //start=true;
				}
				else if((fp.y - lp.y) < -80 ) // up swipe
				{
					// add your jumping code here
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) )
        {
            moveForward();
		}
        if (direction == STATE_OF_OBJECT.LEFT) 
        {
			transform.Translate (0,0, Move_along_z.speed);
			//print (direction);
		}

        if (direction == STATE_OF_OBJECT.RIGHT) 
        {
			transform.Translate (0,0, Move_along_z2.speed);
			//print (direction);
		}

        if (Vector3.Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) > 5 * distance) 
        {
			player_position = transform.position;
			//cam.position=new Vector3((Cam_position.x+3*distance),Cam_position.y,Cam_position.z);
			cam.Translate(0.01f,0,0);
		}
        if (Mathf.Abs(transform.position.z) > ref_p.position.z || Vector3
                        .Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) > 14 * distance) 
        {
            direction = STATE_OF_OBJECT.AT_START;
			cam.position=Cam_position;
		}

	}

    private void moveForward()
    {
        transform.position = new Vector3(transform.position.x + distance,
                                           transform.position.y,
                                           transform.position.z); 

        if (direction == STATE_OF_OBJECT.AT_START)
            direction = STATE_OF_OBJECT.LEFT;

        else
            direction = (direction == STATE_OF_OBJECT.LEFT) ? STATE_OF_OBJECT.RIGHT : STATE_OF_OBJECT.LEFT;
    }


}


