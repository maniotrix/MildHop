using UnityEngine;
using System;

public partial class playerJumpLevel2 : MonoBehaviour
{
    public enum STATE_OF_PLAYER
    {
        AT_START,
        PLAYING,
    };

    public Transform object0;                           // Used to get distance
    public Transform object1;                           // Used to get distance
    public Transform ref_p;                             // reference object
    public Transform mainCam;                           // Main Camera
    float distance;                                     // Distance between lines         
    public static STATE_OF_PLAYER currentStatus;        // State of player object
    public static Vector3 initialPositionPlayer;        // Initial Position of Player 
    public int currentPosition = -1;

    //  For Touch Inputs Only
    private Vector2 fp;                                 //  first finger position
    private Vector2 lp;                                 //  last finger position

    // Use this for initialization
    void Start()
    {
        try
        {
            currentStatus = STATE_OF_PLAYER.AT_START;
            currentGameState = GAME_STATE.BEFORE_PLAYING;
            distance = Vector3.Distance(object0.position, object1.position);
            initialPositionPlayer = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            currentPosition = -1;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
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
                        if (currentStatus == STATE_OF_PLAYER.AT_START && touch.deltaPosition.y > 0)
                            transform.Translate(0.1f, 0, 0);

                        else if (currentStatus == STATE_OF_PLAYER.AT_START && touch.deltaPosition.y < 0)
                            transform.Translate(-0.1f, 0, 0);

                    }
                    if (touch.phase == TouchPhase.Ended)
                    {

                        if ((fp.x - lp.x) > 80) // left swipe
                        {

                        }
                        else if ((fp.x - lp.x) < -80) // right swipe
                        {
                            //moveForward();
                        }
                        else if ((fp.y - lp.y) < -80) // up swipe
                        {
                            // add your jumping code here
                        }
                    }
                }       //  Touch Inputs

                if (Input.GetKeyDown(KeyCode.Space) ||      //  Space is Pressed ( Computer)
                    Input.GetKeyDown(KeyCode.RightArrow))   //  Right Arrow is Pressed
                {
                    moveForward();
                }

                //  Level Over
                if (Vector3.Distance(transform.position, initialPositionPlayer) > 22 * distance)
                {
                    currentGameState = GAME_STATE.LEVEL_OVER;
                }

                //  Movement of Player at START position(Keyboard)
                if (Input.GetKey(KeyCode.UpArrow) &&        //  Up Arrow is Pressed
                    currentStatus == STATE_OF_PLAYER.AT_START)  //  At Start
                {
                    transform.Translate(Math.Abs(MoveAlongZLevel2.speed[0]) + 0.02f, 0, 0);
                }

                else if (Input.GetKey(KeyCode.DownArrow) && //  Down Arrow is Pressed
                    currentStatus == STATE_OF_PLAYER.AT_START)  //  At Start
                {
                    transform.Translate(-Math.Abs(MoveAlongZLevel2.speed[0]) - 0.02f, 0, 0);
                }

                if (currentStatus == STATE_OF_PLAYER.PLAYING)
                {
                    transform.Translate(-MoveAlongZLevel2.speed[currentPosition], 0, 0);
                }

                // Move Camera when player starts and stops when camera and player lie on same line
                if (currentStatus != STATE_OF_PLAYER.AT_START &&
                    transform.position.x > mainCam.position.x)
                {
                    mainCam.Translate((transform.position.x - mainCam.position.x) * 0.0075f, 0, 0);
                }

                //  Game over : Player Out of sceen
                if (Mathf.Abs(transform.position.z) > ref_p.position.z)
                {
                    currentGameState = GAME_STATE.GAME_OVER;
                }
            }

        }   //  try
        catch (Exception e)
        {
            print(e.Message + currentPosition.ToString());
        }
    }

    // Method  called if Collision Occurs b/w player and any Obj
    void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.name[1] == 'o')
            {
                currentGameState = GAME_STATE.GAME_OVER;
            }
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }

    private void moveForward()          //  Move Forward
    {
        try
        {
            transform.position = new Vector3(transform.position.x + distance,
                                               transform.position.y,
                                               transform.position.z);

            if (currentStatus == STATE_OF_PLAYER.AT_START)
                currentStatus = STATE_OF_PLAYER.PLAYING;

            currentPosition++;

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
