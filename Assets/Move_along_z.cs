using UnityEngine;
using System.Collections;

public class Move_along_z : MonoBehaviour {
	public Transform ref_g;
	public static float speed=0.03f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(transform.position.z) >= ref_g.position.z) {
			///speed=-speed;
			//transform.position=new Vector3(transform.position.x,
			  //                             transform.position.y,transform.position.z-2*transform.position.z);
		
		speed=-speed;
		}
		if (Time.timeScale == 1) {
						transform.Translate (0, 0, speed);
				}
	
}
}
