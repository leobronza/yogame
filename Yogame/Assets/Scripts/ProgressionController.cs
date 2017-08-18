using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {
	
	// Score
	private float progressionScore = 1.2f; 
	private float progressionScoreLiberty = 2f;
	private int nextScorePoint = 10;
	private int previousScorePoint = 10;


	private GameObject enemyTeam;

	// Enemy Amount
	private float progressionAmountEnemy = 1.2f; 
	private float progressionAmountEnemyLiberty = 1.33f;
	private int nextScoreAmountEnemy = 11; 
	private int amountEnemies = 3;
	private int amountEnemyInt = 1;

	// Move Speed Enemy
	private float progressionMoveSpeedEnemy = 1.2F; 
	private float progressionMoveSpeedEnemyLiberty = 1.33f;
	private int nextScoreMoveSpeedEnemy = 11;
	private float moveSpeedEnemies = 1.0f;
	private int moveSpeedEnemyInt = 1;

	void Start () {
		enemyTeam = GameObject.FindGameObjectWithTag ("EnemyTeam");
		enemyTeam.GetComponent<Respawn>().setAmountMinions(amountEnemies);
		enemyTeam.GetComponent<Respawn> ().setMoveSpeed (moveSpeedEnemies);
	}

	public void onMinionKilled(int score){
		
		// Score
		if (score == nextScorePoint) {
			// Score
			previousScorePoint = score;
			nextScorePoint = (int)Random.Range ((float)nextScorePoint * progressionScore, (float)nextScorePoint *  progressionScore * progressionScoreLiberty);
			print ("Next Score; " + nextScorePoint);

			int ScoreStep = (nextScorePoint - previousScorePoint); 

			//Enemy Amount
			nextScoreAmountEnemy = (int)(ScoreStep/ ((int)Random.Range ((float)amountEnemies * progressionAmountEnemy, (float)amountEnemies * progressionAmountEnemy * progressionAmountEnemyLiberty) - amountEnemies + 1));
			amountEnemyInt = 1;

			//Move Speed Enemy
			nextScoreMoveSpeedEnemy = (int)(ScoreStep/((int)Random.Range (moveSpeedEnemies * progressionMoveSpeedEnemy, moveSpeedEnemies * progressionMoveSpeedEnemy * progressionMoveSpeedEnemyLiberty) - moveSpeedEnemies + 1));
			moveSpeedEnemyInt = 1;
		} 

		// Enemy Amount
		if(score == previousScorePoint + nextScoreAmountEnemy * amountEnemyInt){
			enemyTeam.GetComponent<Respawn> ().plusAmountMinions();
			amountEnemies++;
			amountEnemyInt++;
			print ("Next Point to plus Enemy: " + nextScoreAmountEnemy * amountEnemyInt);
		}

		// Move Speed Enemy
		if(score == previousScorePoint + nextScoreMoveSpeedEnemy * moveSpeedEnemyInt){
			enemyTeam.GetComponent<Respawn> ().plusMoveSpeed();
			moveSpeedEnemies += 0.2f;
			moveSpeedEnemyInt++;
			print ("Next Point to plus Enemy Move Speed: " + nextScoreMoveSpeedEnemy * moveSpeedEnemyInt);
		}


	}
		
}
