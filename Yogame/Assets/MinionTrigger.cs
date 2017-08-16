using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionTrigger : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		Debug.Log ("ENTER");
	}
	void OnTriggerExit(Collider other){
		Debug.Log ("Exit");
	}
	void OnTriggerStay(Collider other){
		Debug.Log ("Stay");
	}

	void OnCollisionEnter2D(Collision2D colission){
		Debug.Log ("Algo me bateu");
	}
}
