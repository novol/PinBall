using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	private float flickAngle = -20;

//	private bool onRight = false;
//	private bool onLeft = false;


	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();
		setAngle (this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0) {
			foreach(Touch t in Input.touches)
			{

				Debug.Log ("tag:" + tag + " Screen.width:" + Screen.width + " position.x:" + t.position.x);

				switch (t.phase) {
				case TouchPhase.Began:
					if (t.position.x >= (Screen.width / 2) && tag == "RightFripperTag") {
						setAngle (this.flickAngle);
//						this.onRight = true;
					}
					if (t.position.x < (Screen.width / 2) && tag == "LeftFripperTag") {
						setAngle (this.flickAngle);
//						this.onLeft = true;
					}
					break;
				case TouchPhase.Moved:
					break;
				case TouchPhase.Canceled:
				case TouchPhase.Ended:

//					Debug.Log ("tag:" + tag + " onLeft:" + this.onLeft + " onRight:" + this.onRight);
					Debug.Log ("tag:" + tag);

					if (t.position.x >= (Screen.width / 2) && tag == "RightFripperTag") {
						setAngle (this.defaultAngle);
					}
					if (t.position.x < (Screen.width / 2) && tag == "LeftFripperTag") {
						setAngle (this.defaultAngle);
					}

//					if (this.onRight == true && tag == "RightFripperTag") {
//						setAngle (this.defaultAngle);
//						this.onRight = false;
//					}
//					if (this.onLeft == true  && tag == "LeftFripperTag") {
//						setAngle (this.defaultAngle);
//						this.onLeft = false;
//					}
					break;
				}
			}
		}

// ----------------------
// 課題用にコメント止め
// ----------------------
//
//		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
//			setAngle (this.flickAngle);
//		}
//
//		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
//			setAngle (this.flickAngle);
//		}
//
//		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
//			setAngle (this.defaultAngle);
//		}
//
//		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
//			setAngle (this.defaultAngle);
//		}
//
//　ここまで
// ---------------------

	}

	public void setAngle(float angle) {
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}

}
