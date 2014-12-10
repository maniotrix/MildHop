using UnityEngine;
using System.Collections;

public class playerJump : MonoBehaviour
{
    public enum STATE_OF_OBJECT                         // State of Player
    {
        AT_START,
        LEFT,
        RIGHT
    } ;

    public Transform object0;                           // Used to get distance
    public Transform object1;                           // Used to get distance
	public Transform ref_p;                             // reference object
	public Transform mainCam;                           // Main Camera
    float distance;                                     //  Distance between lines
	public static Transform startCam;                
	public static float Yposition=0.0f;
	public static float Xposition=0.0f;
	public static float Zposition=0.0f;
    public static STATE_OF_OBJECT direction;            //  State of object
	public static Vector3 Cam_position;
	Vector3 player_position ;

    //  For Touch Inputs Only
	private Vector2 fp;                                 // first finger position
	private Vector2 lp;                                 // last finger position


	// Use this for initialization
	void Start ()
	{
        direction = STATE_OF_OBJECT.AT_START;
        distance = 0.0f;
        startCam = mainCam;
		player_along_z.speed = 0.0f;
		Yposition = transform.position.y;
		Xposition = transform.position.x;
		Zposition = transform.position.z;
		distance = Vector3.Distance (object0.position, object1.position);
		Cam_position = startCam.position;
		player_position = new Vector3 (Xposition, Yposition, Zposition);
	}

	// Update is called once per frame
	void Update ()
	{	
		// Getting Touch Inputs(Phone Only)
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
				}
				else if((fp.y - lp.y) < -80 ) // up swipe
				{
					// add your jumping code here
				}
			}
		}

        // Space is Pressed ( Computer)
		if (Input.GetKeyDown(KeyCode.Space) )
        {
            moveForward();
		}

        if (direction == STATE_OF_OBJECT.LEFT) 
        {
			transform.Translate (0,0, Move_along_z.speed);
		}

        if (direction == STATE_OF_OBJECT.RIGHT) 
        {
			transform.Translate (0,0, Move_along_z2.speed);
		}

        // Move Camera when player starts
        if (direction != STATE_OF_OBJECT.AT_START)
        {
            startCam.Translate(0.01f, 0, 0);
        }

        //  Game over
        if (Mathf.Abs(transform.position.z) > ref_p.position.z || Vector3
                        .Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) > 14 * distance) 
        {
            gameOver();
		}

	}

    private void moveForward()          //  Move Forward
    {
        transform.position = new Vector3(transform.position.x + distance,
                                           transform.position.y,
                                           transform.position.z); 

        if (direction == STATE_OF_OBJECT.AT_START)
            direction = STATE_OF_OBJECT.LEFT;

        else
            direction = (direction == STATE_OF_OBJECT.LEFT) ? STATE_OF_OBJECT.RIGHT : STATE_OF_OBJECT.LEFT;
    }

    private void gameOver()             // Game Over
    {
        direction = STATE_OF_OBJECT.AT_START;
        transform.position = new Vector3(Xposition, Yposition, Zposition);
        startCam.position = Cam_position;
    }
}


