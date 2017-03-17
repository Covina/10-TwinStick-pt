using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	// create a constant to store the number of replay frames
	private const int BUFFERFRAMES = 100;

	// create an array to store all the data for that frame
	private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFERFRAMES];

	// rigid body of the ball.
	private Rigidbody rigidBody;

	// Get the game manager
	private GameManager manager;


	private bool recordOn = true;
	private bool playbackOn = false;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody>();
		manager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		// Record
		if (manager.isRecordingOn == true) {
			Record ();
		}

		// Play Back
		if (manager.isRecordingOn == false) {
			PlayBack ();
		}


	}

	/// <summary>
	/// Stores frame game data for replay
	/// </summary>
	public void Record ()
	{

		// Announce new state change
		if (recordOn == false) {
			playbackOn = false;
			recordOn = true;
			Debug.Log("Playback OFF -> Recording ON");
		}


		// make sure physics engine is moving object during record mode
		rigidBody.isKinematic = false;

		// get the frame value;
		int frame = Time.frameCount % BUFFERFRAMES;

		// get the time
		float time = Time.time;
		Debug.Log ("Recording current Frame: " + frame);

		// populate the frame data.
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}


	public void PlayBack ()
	{

		// Announce new state change
		if (playbackOn == false) {
			recordOn = false;
			playbackOn = true;
			Debug.Log("Recording OFF -> PlayBack ON");
		}

		// set object to be moved by script during playback
		rigidBody.isKinematic = true;

		// figure out which frame to play
		int frame = Time.frameCount % BUFFERFRAMES;

		// get the position and rotation values from struct object at that frame;
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;

		//Debug.Log("Frame[" + frame + "]:  transform.position [" + transform.position + "] || transform.rotation [" + transform.rotation + "]);


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