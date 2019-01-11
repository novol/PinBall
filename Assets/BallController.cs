using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	private float visiblePoz = -6.5f;
	private GameObject gameoverText;

	/*
	 * -----------------
	 * 課題
	 * -----------------
	 */
	private float score = 0.0f;
	private GameObject scoreText;


	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find ("GameOverText");

		/*
		 * ------------------
		 * 課題
		 * ------------------
		 */
		this.scoreText = GameObject.Find ("ScoreText");

	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z < this.visiblePoz) {
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	/*
	 * ----------------
	 * 課題
	 * ----------------
	 */
	void OnCollisionEnter(Collision other) {

		string tag = other.gameObject.tag;

		if (tag == "SmallStarTag") {
			this.score += 10f;
		} else if (tag == "LargeStarTag") {
			this.score += 100f;
		} else if (tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.score = this.score + 1f;
		} else {
		}
		this.scoreText.GetComponent<Text> ().text = "Score: " + this.score;
	}

}
