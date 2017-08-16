using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitKill : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	public int score;
	public int points = 1;
	public GameObject modelKnife;
	private GameObject knife;
	public GameObject yoda;
	private GameObject[] arrayTarget;
	public GameObject[] arrayKnife;
	void Start () {
		arrayKnife = new GameObject[5];
		arrayTarget = new GameObject[5];

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) { 
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
					ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
					//Debug. Ray (ray.origin, ray.direction * 20, Color.red);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					//Debug.Log ("Hit Something");
					for (int i = 0; i < arrayKnife.Length ; i++) {
						if (arrayKnife[i] == null) {
							arrayKnife[i] = Instantiate (modelKnife, new Vector3(yoda.transform.position.x,yoda.transform.position.y + 0.5f,yoda.transform.position.z), Quaternion.identity);
							arrayTarget[i] = hit.transform.gameObject;
							arrayKnife[i].transform.LookAt (arrayTarget[i].transform.position);
							i=5;
						}
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
		for(int i = 0; i <  arrayKnife.Length ; i++){
			if (arrayKnife[i] != null) {
				if ( arrayTarget [i] == null || Vector3.SqrMagnitude (arrayKnife [i].transform.position - arrayTarget [i].transform.position) < 1f) {
					if ( arrayTarget [i] != null && arrayTarget [i].GetComponent <MinionHealth> ().damage (25f)) {
						score += points;
					}
					Destroy (arrayKnife[i]);
					arrayTarget [i] = null;
				} else  {
					arrayKnife [i].transform.LookAt (arrayTarget [i].transform.position);
					arrayKnife [i].transform.position += new Vector3 (arrayKnife [i].transform.forward.x, 0, arrayKnife [i].transform.forward.z) * Time.deltaTime * 10f;
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
