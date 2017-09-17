using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {
	
	// Score
	private int progressionScore = 60; 
	private int progressionScoreLiberty = 90;
	private int nextScorePoint = 10;
	private int previousScorePoint = 10;


	private GameObject enemyTeam;

	// Enemy Amount
	private int progressionAmountEnemy = 1; 
	private int progressionAmountEnemyLiberty = 2;
	private int stepScoreAmountEnemy = 11; 
	private int amountEnemies = 3;
	private int amountEnemyInt = 1;
	private int amountEnemyIncrease = 0;

	// Move Speed Enemy
	private int progressionMoveSpeedEnemy = 1; 
	private int progressionMoveSpeedEnemyLiberty = 2;
	private int stepScoreMoveSpeedEnemy = 11;
	private int moveSpeedEnemies = 1; // 1 = 0.05
	private int moveSpeedEnemyInt = 1;
	private int moveSpeedEnemyIncrease = 0;

	// Attack Enemy
	private int progressionAttackEnemy = 1; 
	private int progressionAttackEnemyLiberty = 2;
	private int stepScoreAttackEnemy = 11;
	private int attackEnemies = 1; // 1 = 0.05 ??
	private int attackEnemyInt = 1;
	private int attackEnemyIncrease = 0;

	void Start () {
		enemyTeam = GameObject.FindGameObjectWithTag ("EnemyTeam");
		resetProgression ();
	}

	public void onMinionKilled(int score){
		
		// Score
		if (score == nextScorePoint) {
			// Score
			previousScorePoint = score;
			nextScorePoint = (int)Random.Range (nextScorePoint + progressionScore, nextScorePoint + progressionScoreLiberty);
			print ("Next Score: " + nextScorePoint);

			int ScoreStep = (nextScorePoint - previousScorePoint); 

			//Enemy Amount
			amountEnemyIncrease = Random.Range (amountEnemies + progressionAmountEnemy, amountEnemies +  progressionAmountEnemyLiberty) + 1 ;
			stepScoreAmountEnemy = (int)ScoreStep / amountEnemyIncrease;
			amountEnemyInt = 1;

			//Move Speed Enemy
			moveSpeedEnemyIncrease = Random.Range (moveSpeedEnemies + progressionMoveSpeedEnemy, moveSpeedEnemies + progressionMoveSpeedEnemyLiberty) + 1;
			stepScoreMoveSpeedEnemy = (int)ScoreStep / moveSpeedEnemyIncrease;
			amountEnemyInt = 1;

			// Attack Enemy
			attackEnemyIncrease = Random.Range (attackEnemies + progressionAttackEnemy, attackEnemies + progressionAttackEnemyLiberty) + 1;
			stepScoreAttackEnemy = (int)ScoreStep / attackEnemyIncrease;
			attackEnemyInt = 1;
		} 

		// Enemy Amount
		if(score == previousScorePoint + stepScoreAmountEnemy * amountEnemyInt && amountEnemyInt <= moveSpeedEnemyIncrease){
			enemyTeam.GetComponent<Respawn> ().plusAmountMinions();
			amountEnemies++;
			amountEnemyInt++;
			print ("Next Point to plus Enemy: " + previousScorePoint + stepScoreAmountEnemy * amountEnemyInt);
		}

		// Move Speed Enemy
		if(score == previousScorePoint + stepScoreMoveSpeedEnemy * moveSpeedEnemyInt  && moveSpeedEnemyInt <= moveSpeedEnemyIncrease ){
			enemyTeam.GetComponent<Respawn> ().plusMoveSpeed();
			moveSpeedEnemies++;
			moveSpeedEnemyInt++;
			print ("Next Point to plus Enemy Move Speed: " + previousScorePoint + stepScoreMoveSpeedEnemy * moveSpeedEnemyInt );
		}

		// Attack Enemy
		if(score == previousScorePoint + stepScoreAttackEnemy * attackEnemyInt  && attackEnemyInt <= attackEnemyIncrease ){
			enemyTeam.GetComponent<Respawn> ().plusAttack();
			attackEnemies++;
			attackEnemyInt++;
			print ("Next Point to plus Enemy Attack: "+ previousScorePoint + stepScoreAttackEnemy * attackEnemyInt );
		}

	}
		
	public void resetProgression(){
		enemyTeam.GetComponent<Respawn>().setAmountMinions(3);
		enemyTeam.GetComponent<Respawn> ().setMoveSpeed (1.0f);
		enemyTeam.GetComponent<Respawn> ().setAttack (25.0f);
		nextScorePoint = 10;
		previousScorePoint = 10;
		amountEnemies = 3;
		moveSpeedEnemies = 1;
		attackEnemies = 1;
		}
}
