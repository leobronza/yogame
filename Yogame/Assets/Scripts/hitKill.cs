using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitKill : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	public int score;
	public int points = 1;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) { 
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
					ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
					//Debug. Ray (ray.origin, ray.direction * 20, Color.red);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					//Debug.Log ("Hit Something");
					if (hit.transform.gameObject.GetComponent <MinionHealth> ().damage (25f)) {
						
						score += points;
					}
					//Debug.Log (hit.transform);
				}	
			}
		}else	

	if(Input.GetMouseButtonDown(0)){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if (hit.transform.gameObject.GetComponent <MinionHealth> ().damage (25f)) {
					score += points;
				}
			}
		}
	}
		
	void OnGUI(){
		GUIStyle centeredTextStyle = new  GUIStyle ("label");
		centeredTextStyle.alignment = TextAnchor.MiddleCenter;
		centeredTextStyle.fontSize = 40;
		GUI.Label(new Rect (0,0,Screen.width,30),score.ToString(),centeredTextStyle);

	}
}
