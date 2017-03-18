using UnityEngine;
using System.Collections;

public class SelfieStick : MonoBehaviour {

	// camera pan speed for the selfie stick
	private float panSpeed = 5f;

	// get the player
	private GameObject player;

	// support for the selfie stick rotation
	private Vector3 armRotation;

	// Use this for initialization
	void Start () {

		// get the player object
		player = GameObject.FindGameObjectWithTag("Player");

		// set the starting position on top of player
		transform.position = player.transform.position;

		// assign rotation as vector3, not quaternion
		armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

		// move the stick every frame to stay on top of player
		transform.position = player.transform.position;


		armRotation.x += Input.GetAxis("RVert") * panSpeed;
		armRotation.y += Input.GetAxis("RHoriz") * panSpeed;

		// assign the rotation, but conver it to quaternion first
		transform.rotation = Quaternion.Euler(armRotation);


	}
}
