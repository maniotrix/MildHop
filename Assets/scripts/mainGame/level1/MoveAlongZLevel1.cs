using UnityEngine;
using System.Collections;
using System;

public class MoveAlongZLevel1 : MonoBehaviour 
{
    public Transform refPointGrid;
    public static float[] speed;

	// Use this for initialization
	void Start () 
    {
        speed = new float[21]{
            0.02f,-0.02f,0.02f,-0.02f,
            0.02f,-0.02f,0.02f,-0.02f,
            0.02f,-0.02f,0.02f,-0.02f,
            0.02f,-0.02f,0.02f,-0.02f,
            0.02f,-0.02f,0.02f,-0.02f,
            0.02f
        };
	}
	
	// Update is called once per frame
	void Update () 
    {
        try
        {
            switch (playerJumpLevel1.currentGameState)
            {
                case playerJumpLevel1.GAME_STATE.PLAYING:
                    if (Mathf.Abs(transform.GetChild(0).position.z) >= refPointGrid.position.z)
                    {
                        for (int i = 0; i < speed.Length; ++i)
                            speed[i] = -speed[i];
                    }
                    if (Time.timeScale == 1)
                    {
                        for (int i = 0; i < speed.Length; ++i)
                            transform.GetChild(i).Translate(speed[i], 0, 0); 
                    }
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
