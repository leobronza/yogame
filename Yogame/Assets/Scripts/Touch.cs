using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Touch : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public GameObject modelKnife;
	private GameObject knife;
	public GameObject yoda;
	private GameObject[] arrayTarget;
	public GameObject[] arrayKnife;
	private float holdTime = 0.5f; 
	private float acumTimeHold = 0;
	private Vector3 touchPosition; 
	private bool isTouchPosition;
	private bool pause = false;
	private List<GameObject> knifes;
	private List<GameObject> knifesTargets;
	private bool mouseHold = false;
	private float acumTimeKnife = 0 ;
	private float knifeTime = 0.6f;
	private float velocityKnife = 10f;
	public GameObject modelYodaRotation;
	private GameObject yodaRotation;


	void Start () {
		arrayKnife = new GameObject[5];
		arrayTarget = new GameObject[5];
		knifes = new List<GameObject>();
		knifesTargets = new List<GameObject>();

	}

	void Update () {
		if (!pause) {
			if (Input.touchCount > 0) { 
				if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					acumTimeHold = 0; 
					isTouchPosition = false;

					ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
					//Debug. Ray (ray.origin, ray.direction * 20, Color.red);
					if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
						if (hit.transform.gameObject.tag.Equals ("Enemy")) {
							if (yoda.GetComponent <Stamine> ().chekStaminaKnife ()) {
								for (int i = 0; i < arrayKnife.Length; i++) {
									if (arrayKnife [i] == null) {
										yoda.GetComponent <Stamine> ().decreaseStaminaKnife ();
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
					acumTimeHold += Input.GetTouch (0).deltaTime;
		
					if (isTouchPosition == false) {
						touchPosition	= new Vector3 (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position).x, 0.02F, Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position).z);
						isTouchPosition = true;
					}
					if (acumTimeHold >= holdTime) {
						Collider[] hitColliders = Physics.OverlapSphere (touchPosition, 4.0f);
						int i = 0;
						while (i < hitColliders.Length) {
							if (hitColliders [i].transform.gameObject.tag.Equals ("Enemy")) {
								hitColliders [i].transform.gameObject.GetComponent <MinionHealth> ().damage (25f, 1);
							}
							i++;
						}
					}
				}
			}

	// ************************************************************* Debug ************************************************************
			if (Input.GetMouseButtonUp (0)) {
				yoda.GetComponent<SpriteRenderer> ().enabled = true;
				velocityKnife = 10f;
				mouseHold = false;
				acumTimeHold = 0;
				isTouchPosition = false;
				Destroy (yodaRotation);
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
					if (hit.transform.gameObject.tag.Equals ("Enemy")) {
						if (yoda.GetComponent <Stamine> ().chekStaminaKnife ()) {
							yoda.GetComponent <Stamine> ().decreaseStaminaKnife ();
							knifes.Add (Instantiate (modelKnife, new Vector3 (yoda.transform.position.x, yoda.transform.position.y + 0.3f, yoda.transform.position.z), yoda.transform.rotation));
							knifesTargets.Add (hit.transform.gameObject);
						}
					}
				}                               
			} else if (Input.GetMouseButtonDown (0)) {
				mouseHold = true;
				velocityKnife = 3.5f;
			}
			if (mouseHold) {
				acumTimeHold += Time.deltaTime;

				// save initial touch position
				if (isTouchPosition == false) {
					touchPosition	= new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 0.02F, Camera.main.ScreenToWorldPoint (Input.mousePosition).z);
					isTouchPosition = true;
				}
				if (acumTimeHold >= holdTime) {
					yoda.GetComponent<SpriteRenderer> ().enabled = false;
					if (yodaRotation == null) {
						yodaRotation = Instantiate (modelYodaRotation, new Vector3 (touchPosition.x, 0.01666667f, touchPosition.z), yoda.transform.rotation);
					}
					acumTimeKnife += Time.deltaTime;
					if (acumTimeKnife >= knifeTime) {
						if (yoda.GetComponent <Stamine> ().chekStaminaRotation ()) {
							yoda.GetComponent <Stamine> ().decreaseStaminaRotation ();
							Collider[] hitColliders = Physics.OverlapSphere (touchPosition, 1.4f);
							for (int i = 0; i < hitColliders.Length; i++) {
								if (hitColliders [i].transform.gameObject.tag.Equals ("Enemy")) {
									knifes.Add (Instantiate (modelKnife, new Vector3 (touchPosition.x, yoda.transform.position.y + 0.3f, touchPosition.z), Quaternion.identity));
									knifesTargets.Add (hitColliders [i].transform.gameObject);
								}
							}
						} else {
							mouseHold = false;
							yoda.GetComponent<SpriteRenderer> ().enabled = true;
							Destroy (yodaRotation);
						}
						acumTimeKnife = 0;
					}
				}
			}
	// ************************************************************* Debug ************************************************************


			for (int i = 0; i < knifes.Count; i++) {
				if (knifesTargets [i] == null) {
					Destroy (knifes [i]);
					knifes.RemoveAt (i);
					knifesTargets.RemoveAt (i);
				} else {
					if(Vector3.SqrMagnitude (knifes [i].transform.position -  new Vector3 (knifesTargets [i].transform.position.x, knifesTargets [i].transform.position.y + 0.3f, knifesTargets [i].transform.position.z)) < 1f){
						knifesTargets [i].GetComponent <MinionHealth> ().damage (25f, 1);
						Destroy (knifes [i]);
						knifes.RemoveAt (i);
						knifesTargets.RemoveAt (i);
					}else{
						Vector3 dir = knifesTargets[i].transform.position - knifes[i].transform.position;
						float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
						knifes[i].transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
						knifes[i].transform.rotation = Quaternion.Euler(90.0F, knifes[i].transform.rotation.eulerAngles.y, knifes[i].transform.rotation.eulerAngles.z+90);

						knifes [i].transform.position = Vector3.MoveTowards (knifes [i].transform.position, knifesTargets [i].transform.position, Time.deltaTime * velocityKnife);

						//knifes [i].transform.LookAt (new Vector3 (knifesTargets [i].transform.position.x, knifesTargets [i].transform.position.y + 0.3f, knifesTargets [i].transform.position.z));
						//knifes [i].transform.position += new Vector3 (1, 0, 1) * Time.deltaTime * velocityKnife;
					}
				}
			}

		}
	}


	public void setPause(bool pause){
		this.pause = pause;
	}
}
