﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	//private bool recording = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("Replay")){
			BroadcastMessage ("OnSetRecording",false);
		}else if(CrossPlatformInputManager.GetButtonUp ("Replay")){
			BroadcastMessage ("OnSetRecording", true);
		}
		
	}
}
