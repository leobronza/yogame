using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int score;
	private Text scoreText;
	private int minionPoint = 1;

	void Start () {
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text> ();
	}

	void Update () {
		scoreText.text = score.ToString();
	}

	public void resetScore(){
		this.score = 0;
	}

	public void minionDead(){
		score += minionPoint;
		this.GetComponent<ProgressionController> ().onMinionKilled (score);
	}
}
