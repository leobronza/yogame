using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMoviment : MonoBehaviour {

	private UnityEngine.AI.NavMeshPath path;
	public float moveSpeed;
	private GameObject target;
	private Vector3 targetVector3; 
	private GameObject[] targets;
	private bool manualApproachAndAttack = false;
	private bool resultePath = false;
	private Rigidbody rigidBody;
	private RigidbodyConstraints previousConstraints;
	private float timestamp = 0.0f;

	void Awake () {
		path = new UnityEngine.AI.NavMeshPath();
		rigidBody = this.GetComponent<Rigidbody> ();
		previousConstraints = rigidBody.constraints;
	}

	void Start(){
		this.transform.LookAt (new Vector3 (1f, 0.02f, 1f));
		updateTarget ();
	}
		
	void Update () {
		//this.transform.eulerAngles = new Vector3 (0, this.transform.eulerAngles.y, 0);
		rigidBody.velocity = new Vector3 (0, 0, 0);

		if (target == null) {
			CancelInvoke ();
			manualApproachAndAttack = false;
			rigidBody.mass = 100;
			rigidBody.constraints = previousConstraints;
		}
			

		if (!manualApproachAndAttack) {
			updateTarget ();
		}


		if (target != null) {
			float distanceToTarget = Vector3.Distance (this.transform.position, target.transform.position);
		
			Vector3 forward = this.transform.position +  (this.transform.forward * 0.78f);
			Debug.DrawRay (forward , Vector3.up, Color.yellow, 0.0f);

			float distanceToTargetVector3 = Vector3.Distance (forward, targetVector3);
			if (distanceToTargetVector3 < 0.12f || distanceToTarget < (target.name.Equals ("Nexus") ? 2.3f :1.65f) ) {
				manualApproachAndAttack = true;
			}

			// NavMesh walk
			if (!manualApproachAndAttack && target != null){
				resultePath = UnityEngine.AI.NavMesh.CalculatePath (forward, targetVector3, UnityEngine.AI.NavMesh.AllAreas, path);
				if (resultePath && path.corners.Length > 1) {
					for (int i = 0; i < path.corners.Length - 1; i++) {
						Debug.DrawLine (path.corners [i], path.corners [i + 1], Color.red);	
					}
					//Vector3 x1 = path.corners [1] - path.corners [0];
					//Vector3 x2 = x1.normalized;
					//print (path.corners [0] + new Vector3 (x2.x, x2.y, x2.z));
					//Debug.DrawLine (path.corners [0] + new Vector3(x2.x, x2.y, x2.z) * 0.03f, Vector3.up, Color.blue);
					//transform.LookAt (path.corners [0] + new Vector3 (x2.x, x2.y, x2.z) * 0.03f);
					transform.LookAt (new Vector3 (path.corners [1].x, targetVector3.y, path.corners [1].z));
					//Vector3 direction = new Vector3 (path.corners [1].x, targetVector3.y, path.corners [1].z) - this.transform.position;
					///Debug.DrawRay (direction , Vector3.up, Color.yellow, 0.0f);

					//Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction );
					//print (toRotation);
					//transform.rotation = Quaternion.Lerp(this.transform.rotation, toRotation, 0.5f * Time.time);
					//Quaternion toRotation = Quaternion.Euler(Vector3.Lerp(transform.forward, direction, 0.5f * Time.time));
					//rigidBody.MoveRotation(rigidBody.rotation * toRotation);

					rigidBody.MovePosition (this.transform.position + new Vector3 (this.transform.forward.x, 0, this.transform.forward.z) * Time.deltaTime * moveSpeed);
				} else {
					transform.LookAt (new Vector3 (0f, 0.02f, 0f));
				}
			} 

			// Manual Approach
			if (manualApproachAndAttack && target != null) {
				if (distanceToTarget < (target.name.Equals ("Nexus") ? 1.37f :0.75f)) {
					
					if (target != null) {
						if (Time.time >= timestamp) {
							//InvokeRepeating ("attack", 0.6f, 1);
							attack();
							timestamp = Time.time + 1.0f;
						}
						rigidBody.mass = 100000000;
						rigidBody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
					}
				} else if (distanceToTarget >(target.name.Equals ("Nexus") ? 2.3f :1.65f) ) {
					manualApproachAndAttack = false;
					CancelInvoke ();
					rigidBody.mass = 100;
					rigidBody.constraints = previousConstraints;
				} else {
					timestamp = Time.time + 1.0f;
					this.transform.LookAt (target.transform);
					rigidBody.MovePosition(this.transform.position + new Vector3 (this.transform.forward.x, 0, this.transform.forward.z) * Time.deltaTime * moveSpeed);
				}
			}
		}

	}

	void updateTarget(){
		float lessDistance = 1000f;
		Vector3 conectionPoint;
		UnityEngine.AI.NavMeshHit hit;
		if (this.tag == "Enemy") {
			targets = GameObject.FindGameObjectsWithTag ("Ally");
		} else {
			targets = GameObject.FindGameObjectsWithTag ("Enemy");
		}
		for (int i = 0; i < targets.Length; i++) {
			for (float ang = 0; ang < 360; ang = ang + (targets [i].name.Equals ("Nexus") ? 25 :72)) {
				conectionPoint.x = targets [i].transform.position.x + (targets [i].name.Equals ("Nexus") ? 1.4f :0.78f) * Mathf.Sin (ang * Mathf.Deg2Rad); 
				conectionPoint.y = targets [i].transform.position.y;
				conectionPoint.z = targets [i].transform.position.z + (targets [i].name.Equals ("Nexus") ? 1.4f :0.78f) * Mathf.Cos (ang * Mathf.Deg2Rad);

				if (UnityEngine.AI.NavMesh.SamplePosition (conectionPoint, out hit, 0.07f, UnityEngine.AI.NavMesh.AllAreas)) {
					//Debug.DrawRay (hit.position, Vector3.up, Color.blue, 0.0f);
					float distance = Vector3.Distance (this.transform.position, hit.position);
					if (target == null) {
						target = targets [i];
						targetVector3 = hit.position;
						lessDistance = distance;
					} else if (lessDistance > distance) {
						target = targets [i];
						targetVector3 = hit.position;
						lessDistance = distance;
					}
				}
			}

		}
	}
		
	private void attack(){
		if (target != null) {
			target.GetComponent <MinionHealth> ().damage (25f);
		}
	}
		

	public void setMoveSpeed(float moveSpeed){
		this.moveSpeed = moveSpeed;
	}


}
