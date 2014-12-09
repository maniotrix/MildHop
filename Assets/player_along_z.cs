using UnityEngine;
using System.Collections;

public class player_along_z : MonoBehaviour {
	public static float speed=0.06f*Time.timeScale;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1) {
			transform.Translate (speed, 0, 0);
		}
	}


}
