using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class MinionHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;


	void OnTriggerEnter(Collider other) {
		if (this.tag == "Enemy" && other.gameObject.tag == "Attack" ) {
			Destroy (other.gameObject);
			damage (25f, 1);
		}
	}


	// Use this for initialization
	void Start () {
		cur_Health = max_Health;
		//InvokeRepeating ("decreasehealth", 1f, 1f);
	}
	// source
	// 0 => Minions
	// 1 => Player
	public void damage(float hit, int source){
		if (cur_Health - hit <= 0) {
			if (source == 1) {
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<Score> ().minionDead ();
			}
			Destroy (gameObject);
			//return true;

		} else {
			cur_Health -= hit;
			float calc_Health = cur_Health / max_Health;
			setHealthBar (calc_Health);
			//return false;
		}
	}

	private void setHealthBar(float myHealth){
		//myHealth value 0-1,
		healthBar.transform.localScale = new Vector3(myHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
	}



}
