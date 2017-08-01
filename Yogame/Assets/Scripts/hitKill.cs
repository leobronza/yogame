using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitKill : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) { 
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
					ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
					//Debug.DrawRay (ray.origin, ray.direction * 20, Color.red);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					//Debug.Log ("Hit Something");
					Destroy (hit.transform.gameObject);
					//Debug.Log (hit.transform);
				}	
			}
		}	

	if(Input.GetMouseButtonDown(0)){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
