using UnityEngine;
using System;

public class MoveAlongZLevel3 : MonoBehaviour 
{
    public Transform refPointGrid;
    public static float[] speed;
    private const float xx = 0.04f;

    // Use this for initialization
    void Start () 
    {
        speed = new float[21]{
            xx+0.005f,-xx-0.005f,xx,-xx,
            xx+0.007f,-xx,xx+0.001f,-xx,
            xx-0.001f,-0.00f,xx+0.002f,-xx,
            xx+0.01f,-xx,xx+0.004f,-0.00f,
            xx+0.008f,-xx,xx+0.001f,-xx,
            xx+0.011f
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
