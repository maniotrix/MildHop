using UnityEngine;
using System.Collections;
using System;

public class playerJump : MonoBehaviour
{
    public enum STATE_OF_OBJECT                         // State of Player
    {
        AT_START,
        LEFT,
        RIGHT
    } ;

    public enum GAME_STATE
    {
        BEFORE_PLAYING,
        PLAYING,
        PAUSE,
        GAME_OVER,
        LEVEL_OVER
    };

    public Transform object0;                           // Used to get distance
    public Transform object1;                           // Used to get distance
	public Transform ref_p;                             // reference object
	public Transform mainCam;                           // Main Camera
    float distance;                                     //  Distance between lines
	public static Transform startCam;                
	public static float Yposition=0.0f;
	public static float Xposition=0.0f;
	public static float Zposition=0.0f;
    public static STATE_OF_OBJECT direction;            //  State of player object
    public static GAME_STATE currentGameState;          //  State of Game
	public static Vector3 Cam_position;
	Vector3 player_position ;

    //  For Touch Inputs Only
	private Vector2 fp;                                 //  first finger position
	private Vector2 lp;                                 //  last finger position

	// Use this for initialization
	void Start ()
	{
        try
        {
            direction = STATE_OF_OBJECT.AT_START;
            currentGameState = GAME_STATE.BEFORE_PLAYING;
            distance = 0.0f;
            startCam = mainCam;
            player_along_z.speed = 0.0f;
            Yposition = transform.position.y;
            Xposition = transform.position.x;
            Zposition = transform.position.z;
            distance = Vector3.Distance(object0.position, object1.position);
            Cam_position = startCam.position;
            player_position = new Vector3(Xposition, Yposition, Zposition);
        }
        catch (Exception e)
        {
            print(e.Message);
        }
	}

	// Update is called once per frame
	void Update ()
	{
        try
        {
            //  Will Remove comment after add GUI controls
            if (currentGameState == GAME_STATE.PLAYING)
            {
                // Getting Touch Inputs(Phone Only)
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        fp = touch.position;
                        lp = touch.position;
                    }
                    if (touch.phase == TouchPhase.Moved)
                    {
                        lp = touch.position;

                        //  Movement of Player at START position(Touch)
                        if (direction == STATE_OF_OBJECT.AT_START && touch.deltaPosition.y > 0)
                            transform.Translate(0, 0, 0.1f);

                        else if (direction == STATE_OF_OBJECT.AT_START && touch.deltaPosition.y < 0)
                            transform.Translate(0, 0, -0.1f);

                    }
                    if (touch.phase == TouchPhase.Ended)
                    {

                        if ((fp.x - lp.x) > 80) // left swipe
                        {

                        }
                        else if ((fp.x - lp.x) < -80) // right swipe
                        {
                            moveForward();
                        }
                        else if ((fp.y - lp.y) < -80) // up swipe
                        {
                            // add your jumping code here
                        }
                    }
                }       //  Touch Inputs

                // Space is Pressed ( Computer)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveForward();
                }

                //  Movement of Player at START position(Keyboard)
                if (Input.GetKey(KeyCode.UpArrow) && direction == STATE_OF_OBJECT.AT_START)
                {
                    transform.Translate(0, 0, Math.Abs(Move_along_z.speed) + 0.01f);
                }

                else if (Input.GetKey(KeyCode.DownArrow) && direction == STATE_OF_OBJECT.AT_START)
                {
                    transform.Translate(0, 0, -Math.Abs(Move_along_z2.speed) - 0.01f);
                }

                if (direction == STATE_OF_OBJECT.LEFT)
                {
                    transform.Translate(0, 0, Move_along_z.speed);
                }

                if (direction == STATE_OF_OBJECT.RIGHT)
                {
                    transform.Translate(0, 0, Move_along_z2.speed);
                }

                // Move Camera when player starts and stops when camera and player lie on same line
                if (direction != STATE_OF_OBJECT.AT_START && transform.position.x > startCam.position.x)
                {
                    startCam.Translate((transform.position.x - startCam.position.x) * 0.0075f, 0, 0);
                }

                //  Game over : Player Out of sceen
                if (Mathf.Abs(transform.position.z) > ref_p.position.z)
                {
                    gameOver();
                }

                //  Level Over
                if (Vector3.Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) > 14 * distance)
                {
                    gameOver();
                }
            }

        }   //  try
        catch(Exception e)
        {
            print(e.Message);
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

    void OnGUI()
    {
        switch (currentGameState)
        {
            case GAME_STATE.BEFORE_PLAYING:
                GUI.Box(new Rect(0.25f*Screen.width, 0.25f*Screen.height, 0.5f*Screen.width, 0.5f*Screen.height), "Game Menu");
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Level 1")) 
                {
                    currentGameState = GAME_STATE.PLAYING;
                }

                break;

            case GAME_STATE.PLAYING:
                //sif(GUI.Button(new Rect(Screen.width)))
                break;
            case GAME_STATE.PAUSE:
                break;
            case GAME_STATE.GAME_OVER:
                break;
            case GAME_STATE.LEVEL_OVER:
                break;
            default:
                break;
        }
        
        
        /*if (GUI.Button(new Rect(800, 550, 150, 50), "Jump"))
        {
            moveForward();
        }*/
    }

    private void moveForward()          //  Move Forward
    {
        try
        {
            transform.position = new Vector3(transform.position.x + distance,
                                               transform.position.y,
                                               transform.position.z);

            if (direction == STATE_OF_OBJECT.AT_START)
                direction = STATE_OF_OBJECT.LEFT;

            else
                direction = (direction == STATE_OF_OBJECT.LEFT) ? STATE_OF_OBJECT.RIGHT : STATE_OF_OBJECT.LEFT;
        }
        catch(Exception e)
        {
            print(e.Message);
        }
    }

    private void gameOver()             // Game Over
    {
        try
        {
            direction = STATE_OF_OBJECT.AT_START;
            transform.position = new Vector3(Xposition, Yposition, Zposition);
            startCam.position = Cam_position;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }
}

#if UNITY_EDITOR || UNITY_STANDALONE

#elif UNITY_IPHONE || UNITY_ANDROID || UNITY_WINRT

#endif
