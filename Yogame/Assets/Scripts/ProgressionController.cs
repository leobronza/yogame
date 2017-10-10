using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {
	
	// Score
	private int progressionScore = 50; 
	//private int progressionScoreLiberty = 90;
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

	// Attack Ally
	private int progressionAttackEnemy = 1; 
	private int progressionAttackEnemyLiberty = 2;
	private int stepScoreAttackEnemy = 11;
	private int attackEnemies = 1; // 1 = 0.05 ??
	private int attackEnemyInt = 1;
	private int attackEnemyIncrease = 0;

	private GameObject allyTeam;

	// Ally Amount
	private int progressionAmountAlly = 0; 
	private int progressionAmountAllyLiberty = 1;
	private int stepScoreAmountAlly = 11; 
	private int amountAllies = 1;
	private int amountAllyInt = 1;
	private int amountAllyIncrease = 0;

	// Move Speed Ally
	private int progressionMoveSpeedAlly = 0; 
	private int progressionMoveSpeedAllyLiberty = 1;
	private int stepScoreMoveSpeedAlly = 11;
	private int moveSpeedAllies = 1; // 1 = 0.05
	private int moveSpeedAllyInt = 1;
	private int moveSpeedAllyIncrease = 0;

	// Attack Ally
	private int progressionAttackAlly = 0; 
	private int progressionAttackAllyLiberty = 1;
	private int stepScoreAttackAlly = 11;
	private int attackAllies = 1; // 1 = 0.05 ??
	private int attackAllyInt = 1;
	private int attackAllyIncrease = 0;

	private GameObject specialEnemies;

	// Hastad
	private float scorePointHastad = 10; 

	private float scorePointCagapelado = 10; 


	private bool pauseHorda = false;
	private float acumTimeHorda = 0;
	private float TimeHordaWait = 4;



	void Start () {
		enemyTeam = GameObject.FindGameObjectWithTag ("EnemyTeam");
		allyTeam = GameObject.FindGameObjectWithTag ("AllyTeam");
		specialEnemies = GameObject.FindGameObjectWithTag ("SpecialEnemies");
		resetProgression ();
	}

	void Update () {



		if (pauseHorda &&  GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			acumTimeHorda += Time.deltaTime;
			if (acumTimeHorda >= TimeHordaWait) {
				pauseHorda = false;
				enemyTeam.GetComponent<Respawn> ().setPause (pauseHorda);
				allyTeam.GetComponent<Respawn> ().setPause (pauseHorda);
				specialEnemies.GetComponent<RespawnSpecial> ().setPause (pauseHorda);
				acumTimeHorda = 0;
			}
		}
	}

	public void onMinionKilled(int score){

		//ESCALAR STAMINA !!!!!!!!!

		// Score
		if (score == nextScorePoint) {
			// Score
			previousScorePoint = score;
			nextScorePoint = nextScorePoint + progressionScore;//(int)Random.Range (nextScorePoint + progressionScore, nextScorePoint + progressionScoreLiberty);
			print ("Next Score: " + nextScorePoint);

			// Pause em point aleatorio
			pauseHorda = true;
			enemyTeam.GetComponent<Respawn>().setPause(pauseHorda);
			allyTeam.GetComponent<Respawn> ().setPause (pauseHorda);
			specialEnemies.GetComponent<RespawnSpecial>().setPause(pauseHorda);

			//TODO Escalar especiais
			scorePointHastad = Random.Range (previousScorePoint, nextScorePoint);
			print ("Next point to hastad appear: "+ scorePointHastad); 

			scorePointCagapelado = Random.Range (previousScorePoint, nextScorePoint);
			print ("Next point to Cagapelado appear: "+ scorePointCagapelado); 


			int ScoreStep = (nextScorePoint - previousScorePoint); 

			// Enemy Amount
			amountEnemyIncrease = Random.Range (amountEnemies + progressionAmountEnemy, amountEnemies +  progressionAmountEnemyLiberty) + 1 ;
			stepScoreAmountEnemy = (int)ScoreStep / amountEnemyIncrease;
			amountEnemyInt = 1;

			// Move Speed Enemy
			moveSpeedEnemyIncrease = Random.Range (moveSpeedEnemies + progressionMoveSpeedEnemy, moveSpeedEnemies + progressionMoveSpeedEnemyLiberty) + 1;
			stepScoreMoveSpeedEnemy = (int)ScoreStep / moveSpeedEnemyIncrease;
			amountEnemyInt = 1;

			// Attack Enemy
			attackEnemyIncrease = Random.Range (attackEnemies + progressionAttackEnemy, attackEnemies + progressionAttackEnemyLiberty) + 1;
			stepScoreAttackEnemy = (int)ScoreStep / attackEnemyIncrease;
			attackEnemyInt = 1;

			// Ally Amount
			amountAllyIncrease = Random.Range (amountAllies + progressionAmountAlly, amountAllies +  progressionAmountAllyLiberty) + 1 ;
			stepScoreAmountAlly = (int)ScoreStep / amountAllyIncrease;
			amountAllyInt = 1;

			// Move Speed Ally
			moveSpeedAllyIncrease = Random.Range (moveSpeedAllies + progressionMoveSpeedAlly, moveSpeedAllies + progressionMoveSpeedAllyLiberty) + 1;
			stepScoreMoveSpeedAlly = (int)ScoreStep / moveSpeedAllyIncrease;
			amountAllyInt = 1;

			// Attack Ally
			attackAllyIncrease = Random.Range (attackAllies + progressionAttackAlly, attackAllies + progressionAttackAllyLiberty) + 1;
			stepScoreAttackAlly = (int)ScoreStep / attackAllyIncrease;
			attackAllyInt = 1;

		} 

		// Enemy Amount
		if(score == previousScorePoint + stepScoreAmountEnemy * amountEnemyInt && amountEnemyInt <= amountEnemyIncrease){
			enemyTeam.GetComponent<Respawn> ().plusAmountMinions();
			amountEnemies++;
			amountEnemyInt++;
			print ("Next Point to plus Enemy: " + (previousScorePoint + stepScoreAmountEnemy * amountEnemyInt));
		}

		// Move Speed Enemy
		if(score == previousScorePoint + stepScoreMoveSpeedEnemy * moveSpeedEnemyInt  && moveSpeedEnemyInt <= moveSpeedEnemyIncrease ){
			enemyTeam.GetComponent<Respawn> ().plusMoveSpeed();
			moveSpeedEnemies++;
			moveSpeedEnemyInt++;
			print ("Next Point to plus Enemy Move Speed: " + (previousScorePoint + stepScoreMoveSpeedEnemy * moveSpeedEnemyInt) );
		}

		// Attack Enemy
		if(score == previousScorePoint + stepScoreAttackEnemy * attackEnemyInt  && attackEnemyInt <= attackEnemyIncrease ){
			enemyTeam.GetComponent<Respawn> ().plusAttack();
			attackEnemies++;
			attackEnemyInt++;
			print ("Next Point to plus Enemy Attack: "+ (previousScorePoint + stepScoreAttackEnemy * attackEnemyInt) );
		}

		// Enemy Ally
		if(score == previousScorePoint + stepScoreAmountAlly * amountAllyInt && amountAllyInt <= moveSpeedAllyIncrease){
			allyTeam.GetComponent<Respawn> ().plusAmountMinions();
			amountAllies++;
			amountAllyInt++;
			print ("Next Point to plus Ally: " + (previousScorePoint + stepScoreAmountAlly * amountAllyInt));
		}

		// Move Speed Ally
		if(score == previousScorePoint + stepScoreMoveSpeedAlly * moveSpeedAllyInt  && moveSpeedAllyInt <= moveSpeedAllyIncrease ){
			allyTeam.GetComponent<Respawn> ().plusMoveSpeed();
			moveSpeedAllies++;
			moveSpeedAllyInt++;
			print ("Next Point to plus Ally Move Speed: " + (previousScorePoint + stepScoreMoveSpeedAlly * moveSpeedAllyInt) );
		}

		// Attack Ally
		if(score == previousScorePoint + stepScoreAttackAlly * attackAllyInt  && attackAllyInt <= attackAllyIncrease ){
			allyTeam.GetComponent<Respawn> ().plusAttack();
			attackAllies++;
			attackAllyInt++;
			print ("Next Point to plus Ally Attack: "+ (previousScorePoint + stepScoreAttackAlly * attackAllyInt) );
		}


		if(score == (int)scorePointHastad){
			specialEnemies.GetComponent<RespawnSpecial>().setAmountHastads(1);
		}

		if(score == (int)scorePointCagapelado){
			specialEnemies.GetComponent<RespawnSpecial>().setAmountCagapelados(1);
		}
	}
		
	public void resetProgression(){
		nextScorePoint = 10;
		previousScorePoint = 10;

		enemyTeam.GetComponent<Respawn>().setAmountMinions(3);
		enemyTeam.GetComponent<Respawn> ().setMoveSpeed (1.0f);
		enemyTeam.GetComponent<Respawn> ().setAttack (25.0f);
		amountEnemies = 3;
		moveSpeedEnemies = 1;
		attackEnemies = 1;

		allyTeam.GetComponent<Respawn>().setAmountMinions(1);
		allyTeam.GetComponent<Respawn> ().setMoveSpeed (1.0f);
		allyTeam.GetComponent<Respawn> ().setAttack (25.0f);
		amountAllies = 1;
		moveSpeedAllies = 1;
		attackAllies = 1;
	}
}
