using UnityEngine;
using System.Collections;

<<<<<<< HEAD:Assets/scripts/player_jump.cs
public class player_jump: MonoBehaviour
=======
public class playerJump : MonoBehaviour
>>>>>>> be5f82bcc1c4a311813e64d209a1eadfc1980fbb:Assets/scripts/playerJump.cs
{
    public enum STATE_OF_OBJECT                         // State of Player
    {
        AT_START,
        LEFT,
        RIGHT
    } ;

    public Transform object0;                           // Used to get distance
    public Transform object1;                           // Used to get distance
    public Transform refPointPlayer;                    // reference object
    float distance;                                     //  Distance between lines
	public Transform mainCam;                           // Main Camera
	public static Transform cam;                
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
        cam = mainCam;
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
<<<<<<< HEAD:Assets/scripts/player_jump.cs
		if (Input.GetKeyDown(KeyCode.Space) ){
        
			moveForward();
		}
		if (direction != STATE_OF_OBJECT.AT_START) 
		{
			cam.Translate(0.01f,0,0);
			//print (direction);
=======

        // Space is Pressed ( Computer)
		if (Input.GetKeyDown(KeyCode.Space) )
        {
            moveForward();
>>>>>>> be5f82bcc1c4a311813e64d209a1eadfc1980fbb:Assets/scripts/playerJump.cs
		}

        if (direction == STATE_OF_OBJECT.LEFT) 
        {
			transform.Translate (0,0, Move_along_z.speed);
		}

        if (direction == STATE_OF_OBJECT.RIGHT) 
        {
			transform.Translate (0,0, Move_along_z2.speed);
		}

<<<<<<< HEAD:Assets/scripts/player_jump.cs
       
        if (Mathf.Abs(transform.position.z) > ref_p.position.z || Vector3
                        .Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) > 14 * distance) 
        {
            direction = STATE_OF_OBJECT.AT_START;
			transform.position = new Vector3(Xposition,Yposition,Zposition);
			cam.position=Cam_position;
=======
        // Move Camera when player starts
        if (direction != STATE_OF_OBJECT.AT_START)
        {
            cam.Translate(0.01f, 0, 0);
        }

        //  Game over
        if (Mathf.Abs(transform.position.z) > refPointPlayer.position.z) 
        {
            gameOver();
>>>>>>> be5f82bcc1c4a311813e64d209a1eadfc1980fbb:Assets/scripts/playerJump.cs
		}

        // Level Over
        if (Vector3.Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) > 14 * distance)
        {
            gameOver();             // Only option at this time
        }


	}

    // Method  called if Collision Occurs b/w player and any other cube
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            gameOver();
        }
    }

    //  Move Forward
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

    // Game Over
    public void gameOver()             
    {
        direction = STATE_OF_OBJECT.AT_START;
        transform.position = new Vector3(Xposition, Yposition, Zposition);
        cam.position = Cam_position;
    }
}


