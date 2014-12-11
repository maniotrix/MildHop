using UnityEngine;
using System.Collections;
using System;

public class Move_along_z : MonoBehaviour 
{
    public Transform refPointGrid;
	public static float speed=0.03f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        try
        {
            switch (playerJump.currentGameState)
            {
                case playerJump.GAME_STATE.BEFORE_PLAYING:
                    break;

                case playerJump.GAME_STATE.PLAYING:
                    if (Mathf.Abs(transform.position.z) >= refPointGrid.position.z)
                    {
                        speed = -speed;
                    }
                    if (Time.timeScale == 1)
                    {
                        transform.Translate(0, 0, speed);
                    }
                    break;

                case playerJump.GAME_STATE.PAUSE:
                    break;

                case playerJump.GAME_STATE.GAME_OVER:
                    break;

                case playerJump.GAME_STATE.LEVEL_OVER:
                    break;

                default:
                    break;
            }
            
        }
        catch (Exception e)
        {
            print(e.Message);
        }
	}
}
