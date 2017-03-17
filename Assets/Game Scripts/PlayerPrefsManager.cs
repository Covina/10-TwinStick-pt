using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";


	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.Log("Master Volume value error");
		}
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}


	public static void SetDifficulty(float difficulty)
	{
		PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
	}


	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}


	public static void UnlockLevel (int level)
	{
		// if the level is valid
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			// set the pref through concatenation
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1);
		} else {

			Debug.LogError("Trying to unlock level not in build order.");
		}


	}


	public static bool IsLevelUnlocked (int level)
	{

		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString() );

		// is the value 1?
		bool isLevelUnlocked = (levelValue == 1);


		if(level <= SceneManager.sceneCountInBuildSettings - 1) {
			// it's a valid level so return it
			return isLevelUnlocked;
		} else {

			Debug.LogError("Trying to query level not in build order");
			return false;
		}

	}

}
