using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class MinionHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		cur_Health = max_Health;
		//InvokeRepeating ("decreasehealth", 1f, 1f);
	}

	// Update is called once per frame
	void Update () {

	}

	public bool damage(float hit){
		if (cur_Health - hit <= 0) {
			Destroy (gameObject);
			return true;
		} else {
			cur_Health -= hit;
			float calc_Health = cur_Health / max_Health;
			setHealthBar (calc_Health);
			return false;
		}
	}

	private void setHealthBar(float myHealth){
		//myHealth value 0-1,
		healthBar.transform.localScale = new Vector3(myHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
	}



}
