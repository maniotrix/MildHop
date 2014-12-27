using UnityEngine;
using System;

public class MoveAlongZLevel3 : MonoBehaviour 
{
    public Transform refPointGrid;
    public static float[] speed;

	// Use this for initialization
	void Start () 
    {
        speed = new float[21]{
            0.025f,-0.025f,0.02f,-0.02f,
            0.027f,-0.02f,0.021f,-0.02f,
            0.019f,-0.00f,0.022f,-0.02f,
            0.03f,-0.02f,0.024f,-0.00f,
            0.028f,-0.02f,0.021f,-0.02f,
            0.031f
        };
    }
	
	// Update is called once per frame
	void Update () 
    {
        try
        {
            switch (playerJumpLevel3.currentGameState)
            {
                case playerJumpLevel3.GAME_STATE.PLAYING:
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
