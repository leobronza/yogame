using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMoviment : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	private UnityEngine.AI.NavMeshObstacle obstacle;
	private GameObject target; 
	private bool attacking = false;
	private GameObject[] targets;

	void Awake () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle> ();
		target = GameObject.FindGameObjectWithTag ("Chupinga");
		updateTarget ();
	
	}

	void Update () {
			if (agent.enabled == true && agent.pathPending == false && agent.remainingDistance <= 1.6f &&  agent.remainingDistance != 0){
				agent.enabled = false;
				obstacle.enabled = true;
				obstacle.carving = true;
				if (Vector3.Distance (this.transform.position, target.transform.position) <= 1.6f) {
					attacking = true;
				InvokeRepeating ("attack", 0, 1);
				}

			}
			if (target == null) {
				updateTarget ();
				attacking = false;
			CancelInvoke ();
			}

	}

	void updateTarget(){
		//caca novo alvo
		//float lessDistance = 0f;
		//if (this.tag == "Enemy") {
		//	targets = GameObject.FindGameObjectsWithTag ("Enemy");
		//} else {
		//	targets = GameObject.FindGameObjectsWithTag ("Allies");
		//}
		//for (int i = 0; i < targets.Length; i++) {
		//	if (target == null) {
		//		target = targets [i];
		//		lessDistance = Vector3.Distance (this.transform.position, targets [i].transform.position);
		//	} else if(lessDistance > Vector3.Distance (this.transform.position, targets [i].transform.position)){
		//		target = targets [i];
		//		lessDistance = Vector3.Distance (this.transform.position, targets [i].transform.position);
		//	}
		//}
		agent.SetDestination (target.transform.position);
	}

	public void minionDeadSignal(){
		if(obstacle.enabled == true && attacking == false){
			obstacle.enabled = false;
			agent.enabled = true;
			updateTarget ();
		}
	}
	private void attack(){
		target.GetComponent <MinionHealth> ().damage (2f);
	}
}
