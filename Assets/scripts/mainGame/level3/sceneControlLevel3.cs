using UnityEngine;
using System.Collections;
using System;

public partial class playerJumpLevel3 : MonoBehaviour
{
    //  Game State
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
                try
                {
                    Application.LoadLevel("2levelSelector");//Application.LoadLevel("gameOver");
                }
                catch (Exception e)
                {
                    print(e.Message);
                }
                finally
                {

                }
                break;

            case GAME_STATE.LEVEL_OVER:
                try
                {
                    Application.LoadLevel("2levelSelector");
                }
                catch (Exception e)
                {
                    print(e.Message);
                }
                finally
                {

                }
                break;

            default:
                break;
        }
    }
}
