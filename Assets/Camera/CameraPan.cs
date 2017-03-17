using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {


	private GameObject player;


	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		//print("Rhoriz: " + Input.GetAxis("RHoriz") + " || RVert: " + Input.GetAxis("RVert") );

	}

	// do camera stuff after all physics have completed
	void LateUpdate ()
	{

		// point camera at player
		transform.LookAt(player.transform);
	}

}
