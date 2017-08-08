using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public List<GameObject> enemies;
	public GameObject enemy;
	public int amountEnemies = 4;
	public int team; 

	void Start () {
		enemies = new List<GameObject>();
		for(int i = 0 ; i < amountEnemies ;i++){
			enemies.Add(Instantiate(enemy, new RandomPositionPerTeam().getRandomPositionPerTeam(team, 0F, "BackGround", 0.009F), Quaternion.identity));
		}
	}

	void Update () {
		for (int i = 0; i < amountEnemies; i++) {
			if (i >= enemies.Count) {
				enemies.Add (Instantiate (enemy, new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0F, "BackGround", 0.009F), Quaternion.identity));
			} 
			else if (enemies [i] == null) {
				enemies [i] = Instantiate (enemy, new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0F, "BackGround", 0.009F), Quaternion.identity);
				for (int j = 0; j < amountEnemies; j++) {
					if (j != i) {
						enemies [j].GetComponent<MinionMoviment> ().minionDeadSignal ();
					}
				}
			}
		}
	}
}
