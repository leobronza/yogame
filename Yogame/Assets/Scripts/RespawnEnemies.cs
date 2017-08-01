using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour {
	public GameObject enemy;
	public GameObject chupinga;
	public List<GameObject> enemies; 
	int amountEnemies = 25;
	int activeAgent = -1;

	void Start () {
		enemies = new List<GameObject>();
		for(int i = 0 ; i < amountEnemies ;i++){
			enemies.Add(Instantiate(enemy, new RandomPosition().getRandomPosition(0F, 0.01666667F, 0F), Quaternion.identity));
			enemies[i].GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination (chupinga.transform.position);
		}
	}

	void Update () { 
		for (int i = 0; i < amountEnemies; i++) {
			if (i >= enemies.Count) {
				enemies.Add (Instantiate (enemy, new RandomPosition ().getRandomPosition (0F, 0.01666667F, 0F), Quaternion.identity));
				enemies [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().SetDestination (chupinga.transform.position);
			} else {
				if (enemies [i] == null) {
					enemies [i] = Instantiate (enemy, new RandomPosition ().getRandomPosition (0F, 0.01666667F, 0F), Quaternion.identity);
					enemies [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().SetDestination (chupinga.transform.position);
					activeAgent = 0;

				} else if (enemies [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled == true && enemies [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().remainingDistance <= 1.3f) {
						enemies [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
						enemies [i].GetComponent<UnityEngine.AI.NavMeshObstacle> ().enabled = true;
						enemies [i].GetComponent<UnityEngine.AI.NavMeshObstacle> ().carving = true;
					
				}
			}
		}

		if (activeAgent == 1) {
			for (int j = 0; j < amountEnemies; j++) {
				enemies [j].GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
				enemies [j].GetComponent<UnityEngine.AI.NavMeshAgent> ().SetDestination (chupinga.transform.position);
			}
			activeAgent = -1;
		}
		if (activeAgent == 0) {
			for (int j = 0; j < amountEnemies; j++) {
				enemies [j].GetComponent<UnityEngine.AI.NavMeshObstacle> ().enabled = false;
			}
			activeAgent = 1;
		}

	}
}
	
