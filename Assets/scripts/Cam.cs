using UnityEngine;
using System.Collections;
public class Cam : MonoBehaviour {
///    
///    SmoothFollow:
///        Follows the target's position while applying damping to prevent jittering
///        and immediate moving of the camera.This way every subtle movement doesn't become
///        noticeable. The camera follows from a set distance away from the character and always
///        tries to center the view on the target.
///

// public fields
public Transform target,player ;
public float dampTime = 0.3f;             // offset from the viewport center to fix damping
public float distance = 5;              // distance away on z axis from the target
	private float dist = 5;              // distance away on z axis from the target
	public static bool active=false;
private Vector3 _velocity = Vector3.zero;   // velocity of camera relative to target
	private Vector3 delta,destination;
/// 
///    Update:
///        Makes sure that the camera is always focused on the target, 
///        after applying damping.
///
void Update() {
	//fdist=Vector3.Distance(cube.position,player.position);
	
		// calculate the difference between camera and target positions
		  delta= target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance));
		
		// calculate destination of the camera based on the difference in positions
			 destination = transform.position + delta;
		
		// apply the new position through dampening to provide smooth movement
		transform.position = Vector3.SmoothDamp(transform.position, destination,ref  _velocity, dampTime);
	}

			
		
		
 // eo Update

}