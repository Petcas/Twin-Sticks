using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private int recordIndex = 0;
	private static int totalRecordedFrames = 60 * 50;
	private MyKeyFrame[] myReplay = new MyKeyFrame[totalRecordedFrames];



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		RecordKeyFrame ();

	}

	void RecordKeyFrame () {
		int i = recordIndex % totalRecordedFrames;
		myReplay [i] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
		//print ("Frame Rate: " + 1f / Time.deltaTime + "   Index: " + i + "   Time: " + myReplay [i].frameTime + "   Position: " + myReplay [i].position + "   Rotation: " + myReplay [i].rotation);
		recordIndex += 1;
	}

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
