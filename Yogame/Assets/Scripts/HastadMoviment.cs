using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HastadMoviment : MonoBehaviour {

	private GameObject nexus;
	private float moveSpeed = 2;
	private float attackPower = 50f;
	private bool pause =  false;
	private Vector3 hastadDir;

	void Start () {
		nexus = GameObject.Find("Nexus");
	}

	void Update () {
		if (!pause) {
			Vector3 dir = nexus.transform.position - this.transform.position;
			float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
			this.transform.rotation = Quaternion.Euler(90F, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z-90);
			hastadDir = dir.normalized;


			float distance = Vector3.Distance (new Vector3 (this.transform.position.x, 0, this.transform.position.z), new Vector3 (nexus.transform.position.x, 0, nexus.transform.position.z));
			if (distance < 1.23f) {
				nexus.GetComponent <NexusHealth> ().damage (attackPower);
				Destroy (this.gameObject);
			} else {
				this.transform.position = this.transform.position + new Vector3 (hastadDir.x, 0, hastadDir.z) * Time.deltaTime * moveSpeed;
			}


				
		}
	}

	public void setMoveSpeed(float moveSpeed){
		this.moveSpeed = moveSpeed;
	}

	public void setAttack(float attackPower){
		this.attackPower = attackPower;
	}
	public void setPause(bool pause){
		this.pause = pause;
	}


}
