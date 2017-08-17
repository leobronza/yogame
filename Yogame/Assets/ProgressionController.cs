using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {
	
	private GameObject enemyTeam;
	private int amountEnemies = 3;
	//private int amountAllies = 1;
	private int nextScorePoint = 10;
	private int previousScorePoint = 10;
	private int nextScoreAmountEnemy = 100; // TODO infinito

	private float progression = 1.2F; // TODO Modularizar
	private float progressionLiberty = 2F;

	private float progression2 = 1.2F; // TODO Modularizar
	private float progression2Liberty = 1.33F;

	void Start () {
		enemyTeam = GameObject.FindGameObjectWithTag ("EnemyTeam");

		// TODO get/set 
		enemyTeam.GetComponent<Respawn>().amountEnemies = amountEnemies;
		
	}

	public void onMinionKilled(int score){

		if (score == nextScorePoint) {
			previousScorePoint = score;
			nextScorePoint = (int)Random.Range ((float)nextScorePoint * progression, (float)nextScorePoint *  progression * progressionLiberty);

			nextScoreAmountEnemy = (nextScorePoint - previousScorePoint) / ((int)Random.Range ((float)amountEnemies * progression2, (float)amountEnemies * progression2 * progression2Liberty) - amountEnemies + 1);
		}
		if(score == previousScorePoint + nextScoreAmountEnemy){
			nextScoreAmountEnemy = nextScoreAmountEnemy*2;
			enemyTeam.GetComponent<Respawn> ().amountEnemies++;
		}


	}
		
}
