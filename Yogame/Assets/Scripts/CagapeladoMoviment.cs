using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagapeladoMoviment : MonoBehaviour {

	public GameObject modelToilet;
	private GameObject nexus;
	private float moveSpeed = 1;
	private float attackPower = 50f;
	private bool pause =  false;
	private Vector3 nexusDir;
	private float distance = 0f;
	private float timestamp = 0.0f;
	private List<GameObject> toilets;
	private GameObject toilet;

	void Start () {
		nexus = GameObject.Find("Nexus");
		toilets = new List<GameObject>();
	}

	void Update () {
		if (!pause) {
			Vector3 dir = nexus.transform.position - this.transform.position;
			float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
			this.transform.rotation = Quaternion.Euler(90F, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z-90);
			nexusDir = dir.normalized;

	
			if (distance >= 0.8f) {

				if (Time.time >= timestamp) {
					toilet = Instantiate (modelToilet, new Vector3(this.transform.position.x + nexusDir.x, this.transform.position.y, this.transform.position.z + nexusDir.z), Quaternion.identity, this.transform);
					toilet.transform.rotation = Quaternion.Euler(90.0F, 0, 0);
					toilets.Add (toilet);
					timestamp = Time.time + 3.0f;
				}
			} else {
				this.transform.position = this.transform.position + new Vector3 (nexusDir.x, 0, nexusDir.z) * Time.deltaTime * moveSpeed;
				distance += Time.deltaTime * moveSpeed;
				timestamp = Time.time + 1.0f;
			}


		for (int i = 0; i < toilets.Count; i++) {
			if (toilets [i] == null) {
				toilets.RemoveAt (i);
			} else {
				toilets [i].transform.position = toilets[i].transform.position + new Vector3 (nexusDir.x/1.6f, 0, nexusDir.z/1.6f) * Time.deltaTime * 3.5f;
				toilets [i].transform.Rotate(0,0,Time.deltaTime * 180);
			}
		
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
