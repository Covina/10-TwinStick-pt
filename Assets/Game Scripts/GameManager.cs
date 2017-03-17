using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	// are we recording or playing back
	public bool isRecordingOn = true;

	private bool isGamePaused = false;

	private float initialFixedDeltaTime;

	// Use this for initialization
	void Start () {

		initialFixedDeltaTime = Time.fixedDeltaTime;
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		//Debug.Log("Value of Fire1 (Left CTRL): " + CrossPlatformInputManager.GetAxis("Fire1") );

		// TODO if Fire1 > 0 (button pressed), run PlayBack(), else Record
		if (CrossPlatformInputManager.GetButton ("Fire1")) {

			// turn off recording
			isRecordingOn = false;

		} else {
			// turn record back on
			isRecordingOn = true;
		}


		// Pause the Game
		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame();
		}



	}

	/// <summary>
	/// Pauses the game.
	/// </summary>
	void PauseGame ()
	{
		if (!isGamePaused) {
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
			isGamePaused = true;
		} else {
			Time.timeScale = 1f;
			Time.fixedDeltaTime = initialFixedDeltaTime;
			isGamePaused = false;
		}

	}


	/// <summary>
	/// Raises the application pause event.
	/// </summary>
	/// <param name="pauseStatus">If set to <c>true</c> pause status.</param>
	void OnApplicationPause (bool pauseStatus) {
		isGamePaused = pauseStatus;
	}


}
