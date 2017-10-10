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
	private List<Vector3> knifesDirection;
	private bool mouseHold = false;
	private float acumTimeKnife = 0 ;
	private float knifeTime = 0.6f;
	private float velocityKnife = 10f;
	public GameObject modelYodaRotation;
	private GameObject yodaRotation;
	private bool zeroCost = false;

	void Start () {
		arrayKnife = new GameObject[5];
		arrayTarget = new GameObject[5];
		knifes = new List<GameObject>();
		knifesTargets = new List<GameObject>();
		knifesDirection = new List<Vector3> ();

	}

	void Update () {
		if (!pause) {

			if (Input.touchCount > 0) { 

				if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					yoda.GetComponent<SpriteRenderer> ().enabled = true;
					velocityKnife = 10f;
					mouseHold = false;
					acumTimeHold = 0;
					isTouchPosition = false;
					Destroy (yodaRotation);
					//if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
					//if (hit.transform.gameObject.tag.Equals ("Enemy")) {
					if (zeroCost || yoda.GetComponent <Stamine> ().chekStaminaKnife ()) {
						if (!zeroCost) {
							yoda.GetComponent <Stamine> ().decreaseStaminaKnife ();
						}
					GameObject obj = Instantiate (modelKnife, new Vector3 (yoda.transform.position.x, yoda.transform.position.y + 0.3f, yoda.transform.position.z), yoda.transform.rotation);

					Vector3 knifeDirection = new Vector3 (Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).x, 0.02F, Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).z);

					Vector3 dir = knifeDirection - obj.transform.position;
					float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
					obj.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
					obj.transform.rotation = Quaternion.Euler(90.0F, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z+90);

					knifesDirection.Add (dir.normalized );
					knifes.Add (obj);

					}
					//}
					//}                               
				} else if (Input.GetTouch (0).phase == TouchPhase.Began) {
					mouseHold = true;
					velocityKnife = 3.5f;
				}
				if (mouseHold) {
					acumTimeHold += Time.deltaTime;

					// save initial click position
					if (isTouchPosition == false) {
						touchPosition	= new Vector3 (Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).x, 0.02F, Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position).z+1.0f);
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
								Collider[] hitColliders = Physics.OverlapSphere (touchPosition, 1.7f);
								for (int i = 0; i < hitColliders.Length; i++) {
									if (hitColliders [i].transform.gameObject.tag.Equals ("Enemy") || hitColliders [i].transform.gameObject.tag.Equals ("Hastad") || hitColliders [i].transform.gameObject.tag.Equals ("Cagapelado")) {

										GameObject obj = Instantiate (modelKnife, new Vector3 (touchPosition.x, yoda.transform.position.y + 0.3f, touchPosition.z), Quaternion.identity);
										Vector3 knifeDirection = hitColliders [i].transform.position;

										Vector3 dir = knifeDirection - obj.transform.position;
										float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
										obj.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
										obj.transform.rotation = Quaternion.Euler(90.0F, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z+90);


										knifes.Add (obj);
										knifesDirection.Add (dir.normalized);
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

			}




			// ************************************************************* Debug ************************************************************
			if (Input.GetMouseButtonUp (0)) {
				yoda.GetComponent<SpriteRenderer> ().enabled = true;
				velocityKnife = 10f;
				mouseHold = false;
				acumTimeHold = 0;
				isTouchPosition = false;
				Destroy (yodaRotation);
				//if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
				//if (hit.transform.gameObject.tag.Equals ("Enemy")) {
				if (zeroCost || yoda.GetComponent <Stamine> ().chekStaminaKnife ()) {
					if (!zeroCost) {
						yoda.GetComponent <Stamine> ().decreaseStaminaKnife ();
					}
					GameObject obj = Instantiate (modelKnife, new Vector3 (yoda.transform.position.x, yoda.transform.position.y + 0.3f, yoda.transform.position.z), yoda.transform.rotation);

					Vector3 knifeDirection = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 0.02F, Camera.main.ScreenToWorldPoint (Input.mousePosition).z);

					Vector3 dir = knifeDirection - obj.transform.position;
					float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
					obj.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
					obj.transform.rotation = Quaternion.Euler(90.0F, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z+90);

					knifesDirection.Add (dir.normalized );
					knifes.Add (obj);

				}
				//}
				//}                               
			} else if (Input.GetMouseButtonDown (0)) {
				mouseHold = true;
				velocityKnife = 2.5f;
			}
			if (mouseHold) {
				acumTimeHold += Time.deltaTime;

				// save initial click position
				if (isTouchPosition == false) {
					touchPosition	= new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 0.02F, Camera.main.ScreenToWorldPoint (Input.mousePosition).z+1.0f);
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
							Collider[] hitColliders = Physics.OverlapSphere (touchPosition, 1.7f);
							for (int i = 0; i < hitColliders.Length; i++) {
								if (hitColliders [i].transform.gameObject.tag.Equals ("Enemy") || hitColliders [i].transform.gameObject.tag.Equals ("Hastad") || hitColliders [i].transform.gameObject.tag.Equals ("Cagapelado") ) {

									GameObject obj = Instantiate (modelKnife, new Vector3 (touchPosition.x, yoda.transform.position.y + 0.3f, touchPosition.z), Quaternion.identity);
									Vector3 knifeDirection = hitColliders [i].transform.position;

									Vector3 dir = knifeDirection - obj.transform.position;
									float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
									obj.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
									obj.transform.rotation = Quaternion.Euler(90.0F, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z+90);


									knifes.Add (obj);
									knifesDirection.Add (dir.normalized);
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

				if (knifesDirection [i] == null || knifes[i] == null 
					|| knifes[i].transform.position.x > 3.576474f ||   knifes[i].transform.position.x < -2.723526f
					|| knifes[i].transform.position.z > 3.968794f ||   knifes[i].transform.position.z < -6.031206f
				) {
					Destroy (knifes [i]);
					knifes.RemoveAt (i);
					knifesDirection.RemoveAt (i);
				} else {
					//if(Vector3.SqrMagnitude (knifes [i].transform.position -  new Vector3 (knifesTargets [i].transform.position.x, knifesTargets [i].transform.position.y + 0.3f, knifesTargets [i].transform.position.z)) < 1f){
					//	knifesTargets [i].GetComponent <MinionHealth> ().damage (25f, 1);
					//	Destroy (knifes [i]);
					//	knifes.RemoveAt (i);
					//	knifesTargets.RemoveAt (i);
					//}else{


					//knifes [i].transform.position = Vector3.MoveTowards (knifes [i].transform.position, knifesDirection [i], Time.deltaTime * velocityKnife);
					knifes [i].transform.position = knifes [i].transform.position + new Vector3 (knifesDirection [i].x, 0,knifesDirection [i].z) * Time.deltaTime * velocityKnife;
					//knifes [i].transform.Rotate (0, 0, Time.deltaTime * 180);
					//knifes [i].transform.LookAt (new Vector3 (knifesTargets [i].transform.position.x, knifesTargets [i].transform.position.y + 0.3f, knifesTargets [i].transform.position.z));
					//knifes [i].transform.position += new Vector3 (1, 0, 1) * Time.deltaTime * velocityKnife;
					//}
				}
			}

		}
	}


	public void setPause(bool pause){
		this.pause = pause;
	}


	public void setZeroCost(bool zeroCost){
		this.zeroCost = zeroCost;
	}
}
