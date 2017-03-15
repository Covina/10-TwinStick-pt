using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Sample constructor
		MyKeyFrame testKey = new MyKeyFrame(1.0f, Vector3.up, Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


// try as a struct vs class
public struct MyKeyFrame {

	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	// Constructor
	public MyKeyFrame(float t, Vector3 pos, Quaternion rot) 
	{
		// Set Values for use in "new MyKeyFrame()"
		frameTime = t;		// time
		position = pos;		// position
		rotation = rot;		// rotation

	}



}