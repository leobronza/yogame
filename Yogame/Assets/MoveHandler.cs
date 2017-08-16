using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour {

	public void Destiny(Vector3 vector){
		Rigidbody rb = this.GetComponent <Rigidbody> ();
		rb.velocity = vector;
	}

}
