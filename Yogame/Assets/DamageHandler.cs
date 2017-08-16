using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

	public int health = 1;

	public float invulPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	// Use this for initialization
	void Start () {
		correctLayer = gameObject.layer;
	}

	void OnTriggerEnter2D(){
		Debug.Log ("Trigger");
		health--;
		invulnTimer = invulPeriod;
		gameObject.layer = 10;
	}
	// Update is calledD once per frame
	void Update () {
		invulnTimer -= Time.deltaTime;
		if(invulnTimer <=0){
			gameObject.layer = correctLayer;
		}
	}
}
