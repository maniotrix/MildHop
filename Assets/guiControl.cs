using UnityEngine;
using System.Collections;
using System;

public partial class playerJump : MonoBehaviour
{
    public enum GAME_STATE
    {
        BEFORE_PLAYING,
        PLAYING,
        PAUSE,
        GAME_OVER,
        LEVEL_OVER
    };

    public static GAME_STATE currentGameState;          //  State of Game

    void OnGUI()
    {
        switch (currentGameState)
        {
            case GAME_STATE.BEFORE_PLAYING:
                GUI.Box(new Rect(0.25f * Screen.width, 0.25f * Screen.height, 0.5f * Screen.width, 0.5f * Screen.height), "Game Menu");
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Play ->"))
                {
                    currentGameState = GAME_STATE.PLAYING; 
                }
                if (GUI.Button(new Rect(0.6125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button1"))
                {
                    // Add ButtonsControls
                }
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.6125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button0"))
                {
                    // Add ButtonsControls
                }
                if (GUI.Button(new Rect(0.6125f * Screen.width, 0.6125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button2"))
                {
                    // Add ButtonsControls
                }
                break;

            case GAME_STATE.PLAYING:
                if (GUI.Button(new Rect(0.8f * Screen.width, 0.8f * Screen.height, 0.185f * Screen.width, 0.185f * Screen.height), "Move F")) 
                {
                    moveForward();
                }
                if (GUI.Button(new Rect(0.8f * Screen.width, 0.6f * Screen.height, 0.185f * Screen.width, 0.185f * Screen.height), "Pause"))
                {
                    currentGameState = GAME_STATE.PAUSE;
                }
                break;

            case GAME_STATE.PAUSE:
                GUI.Box(new Rect(0.25f * Screen.width, 0.25f * Screen.height, 0.5f * Screen.width, 0.5f * Screen.height), "Game Menu");
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Resume ->"))
                {
                    currentGameState = GAME_STATE.PLAYING; 
                }
                if (GUI.Button(new Rect(0.6125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button1"))
                {
                    // Add ButtonsControls
                }
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.6125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button0"))
                {
                    // Add ButtonsControls
                }
                if (GUI.Button(new Rect(0.6125f * Screen.width, 0.6125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button2"))
                {
                    // Add ButtonsControls
                }
                break;

            case GAME_STATE.GAME_OVER:
                GUI.Box(new Rect(0.25f * Screen.width, 0.25f * Screen.height, 0.5f * Screen.width, 0.5f * Screen.height), "Game Over");
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Play Again ->"))
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
                    finally
                    {
                        currentGameState = GAME_STATE.PLAYING; 
                    }
                }
                if (GUI.Button(new Rect(0.6125f * Screen.width, 0.3125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button1"))
                {
                    // Add ButtonsControls
                }
                if (GUI.Button(new Rect(0.3125f * Screen.width, 0.6125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button0"))
                {
                    // Add ButtonsControls
                }
                if (GUI.Button(new Rect(0.6125f * Screen.width, 0.6125f * Screen.height, 0.125f * Screen.width, 0.125f * Screen.height), "Button2"))
                {
                    // Add ButtonsControls
                }
                break;

            case GAME_STATE.LEVEL_OVER:
                goto case GAME_STATE.GAME_OVER;         //  Will be deleted when a method and scence is made for next level
                //break;        //  Comment OUt due to unreachable code

            default:
                break;
        }


        /*if (GUI.Button(new Rect(800, 550, 150, 50), "Jump"))
        {
            moveForward();
        }*/
    }
}
