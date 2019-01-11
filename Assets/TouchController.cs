using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	private HingeJoint LeftHingeJoint;
	private HingeJoint RightHingeJoint;

	private GameObject LeftFripper;
	private GameObject RightFripper;

	private bool onRight = false;
	private bool onLeft = false;

	private float defaultAngle = 20;
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		this.LeftFripper = GameObject.Find ("LeftFripper");
		this.LeftHingeJoint = this.LeftFripper.GetComponent<HingeJoint> ();

		this.RightFripper = GameObject.Find ("RightFripper");
		this.RightHingeJoint = this.RightFripper.GetComponent<HingeJoint> ();

		setAngle ("L",this.defaultAngle);
		setAngle ("R",this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0) {
			foreach (Touch t in Input.touches) {

				switch (t.phase) {
				case TouchPhase.Began:
					if (t.position.x >= (Screen.width / 2)) {
						setAngle ("R",this.flickAngle);
						this.onRight = true;
					}
					if (t.position.x < (Screen.width / 2)) {
						setAngle ("L", this.flickAngle);
						this.onLeft = true;
					}
					break;
				case TouchPhase.Moved:
					break;
				case TouchPhase.Canceled:
				case TouchPhase.Ended:
					
					Debug.Log ("Ended");

					if (this.onRight == true ) {
						setAngle ("R",this.defaultAngle);
						this.onRight = false;
					}
					if (this.onLeft == true) {
						setAngle ("L", this.defaultAngle);
						this.onLeft = false;
					}
					break;
				}
			}
		}
	}


	public void setAngle(string LR, float angle) {

		JointSpring jointSpr;

		switch (LR) {
		case "L":
			jointSpr = this.LeftHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.LeftHingeJoint.spring = jointSpr;
			break;
		case "R":
			jointSpr = this.RightHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.RightHingeJoint.spring = jointSpr;
			break;
		}
	}

}
