using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private bool record = true;
	private int startFrame = 0;
	private int endFrame = 0;
	private const int totalRecordedFrames =  10 * 50; //number of seconds times 50 frames per second
	private MyKeyFrame[] myReplay = new MyKeyFrame[totalRecordedFrames];
	private Rigidbody rigidBody;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (record) {
			RecordKeyFrame ();
		}else{
			PlayBack ();
		}

	}

	void PlayBack(){

		rigidBody.isKinematic = true;
		int frame = startFrame % totalRecordedFrames;
		//Debug.Log ("Playing Back Frame: " + frame + "   startFrame: " + startFrame);
		if (startFrame <= endFrame){
			startFrame++;
		}else{
			startFrame = 0;
		}
		transform.position = myReplay [frame].position;
		transform.rotation = myReplay [frame].rotation;

	}

	void RecordKeyFrame () {
		
		rigidBody.isKinematic = false;
		int frame = startFrame % totalRecordedFrames;
		startFrame++;
		//Debug.Log ("Recording Frame: " + frame + "   startFrame: " + startFrame);
		myReplay [frame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
	}

	void OnSetRecording(bool recording){
		
		record = recording;
		endFrame = startFrame;
		startFrame = 0;
	}


	/// <summary>
	/// A structure for storing time position and rotation of an object.
	/// </summary>
	public struct MyKeyFrame {

		public float frameTime;
		public Vector3 position;
		public Quaternion rotation;

		public MyKeyFrame(float time,Vector3 pos,Quaternion rot){
			frameTime = time;
			position = pos;
			rotation = rot;
		}
	}			
}
