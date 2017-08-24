using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitKill : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public int score;
	public int points = 1;
	public GameObject modelKnife;
	private GameObject knife;
	public GameObject yoda;
	private GameObject[] arrayTarget;
	public GameObject[] arrayKnife;
	private GameObject progressionController;
	private float holdTime = 0.0f; 
	private float acumTime = 0;
	private Vector3 touchPosition; 
	private bool isTouchPosition;

	void Start () {
		arrayKnife = new GameObject[5];
		arrayTarget = new GameObject[5];
		progressionController = GameObject.FindGameObjectWithTag ("ProgressionController");
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) { 
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				acumTime = 0; 
				isTouchPosition = false;

				ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				//Debug. Ray (ray.origin, ray.direction * 20, Color.red);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					if(hit.transform.gameObject.tag.Equals("Enemy")){
					if (yoda.GetComponent <Stamina> ().chekStaminaKnife ()) {
						for (int i = 0; i < arrayKnife.Length; i++) {
							if (arrayKnife [i] == null) {
								yoda.GetComponent <Stamina> ().decreaseStaminaKnife ();
								arrayKnife [i] = Instantiate (modelKnife, new Vector3 (yoda.transform.position.x, yoda.transform.position.y + 0.3f, yoda.transform.position.z), Quaternion.identity);
								arrayTarget [i] = hit.transform.gameObject;
								arrayKnife [i].transform.LookAt (arrayTarget [i].transform.position);
								i = 5;
							}
						}
					}
				}	
			}
			} else {// Phase Canceled??
				acumTime += Input.GetTouch(0).deltaTime;
		
				if (isTouchPosition == false) {
					touchPosition	= new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position).x,0.02F,Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position).z);
					isTouchPosition = true;
				}
				if(acumTime >= holdTime)
				{
					Collider[] hitColliders = Physics.OverlapSphere(touchPosition, 4.0f);
					int i = 0;
					while (i < hitColliders.Length) {
						if (hitColliders [i].transform.gameObject.tag.Equals ("Enemy")) {
							if (hitColliders [i].transform.gameObject.GetComponent <MinionHealth> ().damage (25f)) {
								score += points;
								progressionController.GetComponent<ProgressionController> ().onMinionKilled (score);
							}

						
						}
						i++;
					}
				}



			}
		}
		// ***** para Debug *****
	if(Input.GetMouseButtonDown(0)){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if(hit.transform.gameObject.tag.Equals("Enemy")){
					if (yoda.GetComponent <Stamina> ().chekStaminaKnife ()) {
						for (int i = 0; i < arrayKnife.Length; i++) {
							if (arrayKnife [i] == null) {
								yoda.GetComponent <Stamina> ().decreaseStaminaKnife ();
								arrayKnife [i] = Instantiate (modelKnife, new Vector3 (yoda.transform.position.x, yoda.transform.position.y + 0.3f, yoda.transform.position.z), Quaternion.identity);
								arrayTarget [i] = hit.transform.gameObject;
								arrayKnife [i].transform.LookAt (arrayTarget [i].transform.position);
								i = 5;
							}
						}
					}
				}
			}                               
	}
		// ***** para Debug *****

		for(int i = 0; i <  arrayKnife.Length ; i++){
			if (arrayKnife[i] != null) {
				if ( arrayTarget [i] == null || Vector3.SqrMagnitude (arrayKnife [i].transform.position - 
					new Vector3(arrayTarget [i].transform.position.x,arrayTarget [i].transform.position.y + 0.3f,arrayTarget [i].transform.position.z)) < 1f) {
					if (arrayTarget [i] != null && arrayTarget [i].GetComponent <MinionHealth> ().damage (25f)) {
						score += points;
						progressionController.GetComponent<ProgressionController> ().onMinionKilled (score);
					}
					Destroy (arrayKnife[i]);
					arrayTarget [i] = null;
				} else  {
					
					arrayKnife [i].transform.LookAt (new Vector3(arrayTarget [i].transform.position.x,arrayTarget [i].transform.position.y + 0.3f,arrayTarget [i].transform.position.z));
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
