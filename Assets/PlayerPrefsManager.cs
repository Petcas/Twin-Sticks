using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}else{
			Debug.LogError ("Master Volume Out of Range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if(level <= SceneManager.sceneCountInBuildSettings - 1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); //Use 1 for True = Unlocked
		}else {
			Debug.LogError ("Trying to unlock level out of Build Range.");
		}
	}

	public static void LockLevel(int level){
		if(level <= SceneManager.sceneCountInBuildSettings - 1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 0); //Use 1 for True = Unlocked
		}else {
			Debug.LogError ("Trying to lock level out of Build Range.");
		}
	}

	public static bool IsLevelUnlocked(int level){
		if(level <= SceneManager.sceneCountInBuildSettings - 1){
			int state = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString()); //Use 1 for True = Unlocked
			if(state == 0){
				return false;
			}else if (state == 1){
				return true;
			}else{
				Debug.LogError("Unlock state not in range");
				return false;
			}

		}else {
			Debug.LogError ("Trying to query level out of Build Range.");
			return false;
		}
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		}else {
			Debug.LogError ("Difficulty Out of Range");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
