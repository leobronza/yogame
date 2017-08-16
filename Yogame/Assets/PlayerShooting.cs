using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public GameObject knife;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if(cooldownTimer <= 0){
			Debug.Log ("PEW!");
			cooldownTimer = fireDelay;
			Instantiate (knife, transform.position, transform.rotation);
		}
	}
}
