using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public List<GameObject> enemies;
	public GameObject modelEnemy;
	public int amountEnemies = 4;
	public int team; 
	private Vector3 minionDestination;

	void Start () {
		enemies = new List<GameObject>();
		for(int i = 0 ; i < amountEnemies ;i ++){
			enemies.Add (null);
			minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
			if (!Physics.CheckSphere (minionDestination, 0.49f)) {
				enemies.Insert(i, Instantiate (modelEnemy, minionDestination, Quaternion.identity, this.transform));
				//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
			}
		}
	}

	void Update () {
		for (int i = 0; i < amountEnemies; i++) {
			if (i >= enemies.Count) {
					minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (minionDestination, 0.49f)) {
					enemies.Insert(i, Instantiate (modelEnemy, minionDestination, Quaternion.identity, this.transform));
					//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
				}
			} 
			else if (enemies [i] == null) {
				enemies.Add (null);
				minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (minionDestination, 0.49f)) {
					enemies [i] = Instantiate (modelEnemy, minionDestination, Quaternion.identity, this.transform);
					//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
				}

			}
		}
	}
}
