using UnityEngine;
using System.Collections;

public class acale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var height = Camera.main.orthographicSize * 2.0;
		var width = height * Screen.width / Screen.height;
		transform.localScale = new Vector3((float)width, (float)height, (float)0.1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
