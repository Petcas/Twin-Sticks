using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	//private int recordIndex = 0;
	private const int totalRecordedFrames = 60 * 50;
	private MyKeyFrame[] myReplay = new MyKeyFrame[totalRecordedFrames];
	private Rigidbody rigidBody;

	public bool record = true;



	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		if (record) {

			RecordKeyFrame ();
		}else{
			PlayBack ();
		}

	}

	void PlayBack(){
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % totalRecordedFrames;
		transform.position = myReplay [frame].position;
		transform.rotation = myReplay [frame].rotation;

	}

	void RecordKeyFrame () {
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % totalRecordedFrames;
		myReplay [frame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
		//print ("Frame Rate: " + 1f / Time.deltaTime + "   Index: " + i + "   Time: " + myReplay [i].frameTime + "   Position: " + myReplay [i].position + "   Rotation: " + myReplay [i].rotation);
		//recordIndex += 1;
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
