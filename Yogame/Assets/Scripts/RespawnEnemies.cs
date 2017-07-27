using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour {
	public GameObject[] gameObjects;
	public GameObject enemy;
	public GameObject chupinga;

	void Start () {
		gameObjects = new GameObject[6];
		for(int i = 0 ; i < 6 ;i++){
			gameObjects[i] = Instantiate(enemy, new RandomPosition().getRandomPosition(0F, 0.01666667F, 0F), Quaternion.identity);
			print (new RandomPosition ().getRandomPosition (0F, 0.01666667F, 0F));
			gameObjects[i].GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination (chupinga.transform.position);
		}
	}

	void Update () {
		for(int i = 0 ; i < 6 ;i++){
			if (gameObjects [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled) {
				if (gameObjects [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().remainingDistance <= 1.3f) {
					gameObjects [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = !gameObjects [i].GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled;
					gameObjects [i].GetComponent<UnityEngine.AI.NavMeshObstacle> ().enabled = !gameObjects [i].GetComponent<UnityEngine.AI.NavMeshObstacle> ().enabled;
					gameObjects [i].GetComponent<UnityEngine.AI.NavMeshObstacle> ().carving = true;
				}
			}
			if(gameObjects[i] == null){
				gameObjects [i] = new GameObject ();
				gameObjects[i] = Instantiate(enemy, new RandomPosition().getRandomPosition(0F, 0.01666667F, 0F), Quaternion.identity);
			}
		}
	}
}
