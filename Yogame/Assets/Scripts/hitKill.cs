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
	private float holdTime = 0.8f; 
	private float acumTime = 0;

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
				ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				//Debug. Ray (ray.origin, ray.direction * 20, Color.red);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					if (yoda.GetComponent <Stamina> ().chekStamine ()) {
						yoda.GetComponent <Stamina> ().stamine (20f);
						for (int i = 0; i < arrayKnife.Length; i++) {
							if (arrayKnife [i] == null) {
								arrayKnife [i] = Instantiate (modelKnife, new Vector3 (yoda.transform.position.x, yoda.transform.position.y + 0.3f, yoda.transform.position.z), Quaternion.identity);
								arrayTarget [i] = hit.transform.gameObject;
								arrayKnife [i].transform.LookAt (arrayTarget [i].transform.position);
								i = 5;
							}
						}
					}
				}	
			} else {
				acumTime += Input.GetTouch(0).deltaTime;

				if(acumTime >= holdTime)
				{	

					Collider[] hitColliders = Physics.OverlapSphere(new Vector3(0,0,0), 4.0f);
					print (hitColliders.Length);
					int i = 0;
					while (i < hitColliders.Length)
					{
						if (hitColliders[i].transform.gameObject.GetComponent <MinionHealth> ().damage (25f)) {
							score += points;
							progressionController.GetComponent<ProgressionController> ().onMinionKilled (score);
						}

						i++;
					}
				}



			}
		}

	if(Input.GetMouseButtonDown(0)){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if (hit.transform.gameObject.GetComponent <MinionHealth> ().damage (25f)) {
					score += points;
					progressionController.GetComponent<ProgressionController> ().onMinionKilled (score);
				}
			}
		}
		for(int i = 0; i <  arrayKnife.Length ; i++){
			if (arrayKnife[i] != null) {
				if ( arrayTarget [i] == null || Vector3.SqrMagnitude (arrayKnife [i].transform.position - 
					new Vector3(arrayTarget [i].transform.position.x,arrayTarget [i].transform.position.y + 0.3f,arrayTarget [i].transform.position.z)) < 1f) {
					if ( arrayTarget [i] != null && arrayTarget [i].GetComponent <MinionHealth> ().damage (25f)) {
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
