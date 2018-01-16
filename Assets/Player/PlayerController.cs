using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		print ("H: " + CrossPlatformInputManager.GetAxis("Horizontal"));
		print ("V: " + CrossPlatformInputManager.GetAxis("Vertical")); 
		ReplaySystem.MyKeyFrame myKeyFrame = new ReplaySystem.MyKeyFrame (Time.time, transform.position, transform.rotation);
		print ("Time: " + myKeyFrame.frameTime + "   Position: " + myKeyFrame.position + "   Rotation: " + myKeyFrame.rotation); 
	}
}
