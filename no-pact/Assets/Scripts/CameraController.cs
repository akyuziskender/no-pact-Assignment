 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform target;    // what camera is following
	public float smoothing;

	private Vector3 offset;
	private float lowY; // lowest point that the camera can follow

	public GameObject Alice, Bob;

	// Use this for initialization
	void Start() {
		target = (Alice.activeSelf == true) ? Alice.transform : Bob.transform;
		// Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - target.position;

		lowY = -57;    // lowest y position that the camera can follow
	}

	void FixedUpdate() {
		Vector3 targetCamPos;

		targetCamPos = target.position + offset;    // this gives us where the camera want to be located

		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

		if (transform.position.y < lowY)	// preventing camere to go beyond the lowY
			transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
	}
}