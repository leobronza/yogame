using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChupingaMovment : MonoBehaviour {
	
	private GameObject nexus;
	private float moveSpeed = 0.4f;
	private float attackPower = 50f;
	private float timestamp = 0.0f;
	private bool pause =  false;
	private Vector3 hastadDir;
	public Animation anim;

	// Use this for initialization
	void Start () {
		nexus = GameObject.Find("Nexus");
	}

	// Update is called once per frame
	void Update () {
		if (!pause) {
			Vector3 dir = nexus.transform.position - this.transform.position;
			float angle = Mathf.Atan2 (dir.z, dir.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 0, 1));
			this.transform.rotation = Quaternion.Euler (90F, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z - 90);
			hastadDir = dir.normalized;


			float distance = Vector3.Distance (new Vector3 (this.transform.position.x, 0, this.transform.position.z), new Vector3 (nexus.transform.position.x, 0, nexus.transform.position.z));
			if (distance < 2f) {
				Destroy(this.GetComponent<Animator>());
				if (Time.time >= timestamp) {
					nexus.GetComponent <NexusHealth> ().damage (attackPower);
					timestamp = Time.time + 3.0f;
				}
			} else {
				this.transform.position = this.transform.position + new Vector3 (hastadDir.x, 0, hastadDir.z) * Time.deltaTime * moveSpeed;
				timestamp = Time.time + 1.0f;
			}
		}
	}

	public void setMoveSpeed(float moveSpeed){
		this.moveSpeed = moveSpeed;
	}

	public void setPause(bool pause){
		this.pause = pause;
	}

}
