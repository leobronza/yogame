using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {
	
	public float max_Stamine = 100f;
	public float cur_Stamine = 0f;
	public GameObject stamineBar;
	// Use this for initialization

	void Start () {
		cur_Stamine = max_Stamine;
	}

	// Update is called once per frame
	void Update () {
		if (cur_Stamine < max_Stamine) {
			cur_Stamine += 1f;
			float clac_stamine = cur_Stamine * 0.01f;
			setStamine (clac_stamine);
		}

	}


	public void stamine(float hit){
		cur_Stamine -= hit;
		float calc_stamine =  cur_Stamine / max_Stamine;
		setStamine (calc_stamine);
	}

	private void setStamine(float myStamine){
		//myHealth value 0-1,
		stamineBar.transform.localScale = new Vector3(myStamine,stamineBar.transform.localScale.y,stamineBar.transform.localScale.z);
	}

	public bool chekStamine(){
		return cur_Stamine >= 20f;
	}

}
