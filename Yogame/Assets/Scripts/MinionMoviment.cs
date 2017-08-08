using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMoviment : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	private UnityEngine.AI.NavMeshObstacle obstacle;
	private GameObject target; 
	private bool activeAgent = false;
	private GameObject[] targets;

	void Awake () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle> ();
		//target = GameObject.FindGameObjectWithTag ("Chupinga");
		//updateTarget ();
	
	}

	void Start(){
		updateTarget ();
	}
	void Update () {
			//if (agent.enabled == true && agent.pathPending == false && agent.remainingDistance <= 1.6f &&  agent.remainingDistance != 0){
		if(activeAgent == true){
			agent.enabled = true;
			activeAgent = false;
		}

		if (target == null) {
			CancelInvoke ();
			obstacle.enabled = false;
			activeAgent = true;
			updateTarget ();
		} 



			if (agent.enabled == true && target != null) {
				agent.SetDestination (target.transform.position);
			if (agent.pathPending == false && Vector3.Distance (this.transform.position, agent.destination) <= 0.7f) {
					agent.enabled = false;
					obstacle.enabled = true;
					obstacle.carving = true;
				print (Vector3.Distance (this.transform.position, target.transform.position));
					if (Vector3.Distance (this.transform.position, target.transform.position) <= 0.7f) {
						InvokeRepeating ("attack", 1, 1);
					}


			}
		}

	}

	void updateTarget(){
		//caca novo alvo
		float lessDistance = 0f;
		if (this.tag == "Enemy") {
			targets = GameObject.FindGameObjectsWithTag ("Ally");
		} else {
			targets = GameObject.FindGameObjectsWithTag ("Enemy");
		}
		for (int i = 0; i < targets.Length; i++) {
			if (target == null) {
				target = targets [i];
				lessDistance = Vector3.Distance (this.transform.position, targets [i].transform.position);
			} else if(lessDistance > Vector3.Distance (this.transform.position, targets [i].transform.position)){
				target = targets [i];
				lessDistance = Vector3.Distance (this.transform.position, targets [i].transform.position);
			}
		}
		//print ("target" + target);
		//agent.SetDestination (target.transform.position);
	}

	public void minionDeadSignal(){
		//if(obstacle.enabled == true && attacking == false){
		//	obstacle.enabled = false;
		//	agent.enabled = true;
		//	updateTarget ();
		//}
	}
	private void attack(){
		target.GetComponent <MinionHealth> ().damage (25f);
	}
}
