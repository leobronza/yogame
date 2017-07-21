using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenavmeshagent : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	

	void Update () {
		agent.SetDestination (GameObject.FindGameObjectWithTag ("Chupinga").transform.position);
	}
}
