using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletMoviment : MonoBehaviour {
		
	private Vector3 nexusDir;
	private GameObject nexus;

	void Start () {
		nexus = GameObject.Find("Nexus");
		Vector3 dir = nexus.transform.position - this.transform.position;
		nexusDir = dir.normalized;
	}
	

	void Update () {
		this.transform.position = this.transform.position + new Vector3 (nexusDir.x/1.6f, 0, nexusDir.z/1.6f) * Time.deltaTime * 3.5f;
		this.transform.Rotate(0,0,Time.deltaTime * 180);
	}


}
