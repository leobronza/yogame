﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexuHealth : MonoBehaviour {
	public Image fillImg;
	float timeAmt = 10;
	float time;
	// Use this for initialization
	void Start () {
		time = timeAmt;
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
		}
	}
}
