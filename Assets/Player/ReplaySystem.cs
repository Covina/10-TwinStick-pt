using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	// create a constant to store the number of replay frames
	private const int BUFFERFRAMES = 100;

	// create an array to store all the data for that frame
	private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFERFRAMES];

	// rigid body of the ball.
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		Record ();


	}

	void Record ()
	{
		// make sure physics engine is moving object during record mode
		rigidBody.isKinematic = false;

		// get the frame value;
		int frame = Time.frameCount % BUFFERFRAMES;

		// get the time
		float time = Time.time;
		Debug.Log ("Current Frame: " + frame);

		// populate the frame data.
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}


	void PlayBack ()
	{
		// set object to be moved by script during playback
		rigidBody.isKinematic = true;

		// figure out which frame to play
		int frame = Time.frameCount % BUFFERFRAMES;

		// get the position and rotation values from struct object at that frame;
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;


	}


}







/// <summary>
/// A Structure for storing replay Frame Data
/// </summary>
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