using UnityEngine;
using System.Collections;

public class Camera_Translation : MonoBehaviour {
	public float horizontalSpeed = 1.0F;
	public float verticalSpeed = 1.0F;
	void Update() {
		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		float v = verticalSpeed * Input.GetAxis("Mouse Y");
		transform.Translate(0, 0, -v);
	}
}