﻿using UnityEngine;
using System;

public class MoveAlongZLevel2 : MonoBehaviour
{
    public Transform refPointGrid;
    public static float[] speed;
    private const float xx = 0.04f;

    // Use this for initialization
    void Start()
    {
        speed = new float[21]{
            xx,-xx,xx,-0.0f,
            xx,-0.0f,xx,-xx,
            xx,-0.0f,0.0f,-xx,
            xx,-xx,0.0f,-xx,
            0.0f,-xx,xx,-xx,
            0.0f
        };    
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            switch (playerJumpLevel2.currentGameState)
            {
                case playerJumpLevel2.GAME_STATE.PLAYING:
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
