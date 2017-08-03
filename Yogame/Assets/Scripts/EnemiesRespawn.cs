using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRespawn : MonoBehaviour {

	public List<GameObject> enemies;
	public GameObject enemy;
	int amountEnemies = 4;

	void Start () {
		enemies = new List<GameObject>();
		for(int i = 0 ; i < amountEnemies ;i++){
			enemies.Add(Instantiate(enemy, new RandomPosition().getRandomPosition(0F, 0.01666667F, 0F), Quaternion.identity));
		}
	}

	void Update () {
		for (int i = 0; i < amountEnemies; i++) {
			if (i >= enemies.Count) {
				enemies.Add (Instantiate (enemy, new RandomPosition ().getRandomPosition (0F, 0.01666667F, 0F), Quaternion.identity));
			} 
			else if (enemies [i] == null) {
				enemies [i] = Instantiate (enemy, new RandomPosition ().getRandomPosition (0F, 0.01666667F, 0F), Quaternion.identity);
				for (int j = 0; j < amountEnemies; j++) {
					if (j != i) {
						enemies [j].GetComponent<MinionMoviment> ().minionDeadSignal ();
					}
				}
			}
		}
	}
}
