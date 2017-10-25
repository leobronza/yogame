using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {
	
	// Score
	private int progressionScore = 40; 
	//private int progressionScoreLiberty = 90;
	private int nextScorePoint = 10;
	private int previousScorePoint = 10;

	private float fortune = 1;
	private float weightFortune = 1;

	private GameObject enemyTeam;

	// Enemy Amount
	private float progressionAmountEnemy = 3; 
	private float progressionAmountEnemyLiberty = 4;
	private float stepScoreAmountEnemy = 11; 
	private float amountDivisionEnemies = 1;
	private int amountEnemyInt = 1;
	private float amountDivisionEnemyIncrease = 0;
	private float weightAmountEnemy = 1;

	// Move Speed Enemy
	private float progressionMoveSpeedEnemy = 1; 
	private float progressionMoveSpeedEnemyLiberty = 2;
	private float stepScoreMoveSpeedEnemy = 11;
	private float moveSpeedDivisionEnemies = 1; // 1 = 0.05
	private int moveSpeedEnemyInt = 1;
	private float moveSpeedDivisionEnemyIncrease = 0;
	private float weightMoveSpeed = 1;

	// Attack Enemy
	private float progressionAttackEnemy = 1; 
	private float progressionAttackEnemyLiberty = 2;
	private float stepScoreAttackEnemy = 11;
	private float attackDivisionEnemies = 1; // 1 = 0.05 ??
	private int attackEnemyInt = 1;
	private float attackDivisionEnemyIncrease = 0;
	private float weightAttackEnemy = 1;

	private GameObject allyTeam;

	// Ally Amount
	private float progressionAmountAlly = 0; 
	private float progressionAmountAllyLiberty = 1;
	private float stepScoreAmountAlly = 11; 
	private float amountDivisionAllies = 1;
	private int amountAllyInt = 1;
	private float amountDivisionAllyIncrease = 0;
	private float weightAmountAlly = 1;

	// Move Speed Ally
	private float progressionMoveSpeedAlly = 0; 
	private float progressionMoveSpeedAllyLiberty = 1;
	private float stepScoreMoveSpeedAlly = 11;
	private float moveSpeedDivisionAllies = 1; // 1 = 0.05
	private int moveSpeedAllyInt = 1;
	private float moveSpeedDivisionAllyIncrease = 0;
	private float weightMoveSpeedAlly = 1;

	// Attack Ally
	private float progressionAttackAlly = 0; 
	private float progressionAttackAllyLiberty = 1;
	private float stepScoreAttackAlly = 11;
	private float attackDivisionAllies = 1; // 1 = 0.05 ??
	private int attackAllyInt = 1;
	private float attackDivisionAllyIncrease = 0;
	private float weightAttackAlly = 1;

	private GameObject specialEnemies;

	// Hastad
	private float scorePointHastad = 10; 

	private float scorePointCagapelado = 10; 

	private float scorePointChupinga = 10; 

	private bool pauseHorda = false;
	private float acumTimeHorda = 0;
	private float TimeHordaWait = 4;

	public GameObject yoda;

	void Start () {
		enemyTeam = GameObject.FindGameObjectWithTag ("EnemyTeam");
		allyTeam = GameObject.FindGameObjectWithTag ("AllyTeam");
		specialEnemies = GameObject.FindGameObjectWithTag ("SpecialEnemies");
		resetProgression ();
		yoda = GameObject.FindGameObjectWithTag ("Yoda");
	}

	void Update () {
		if (pauseHorda &&  GameObject.FindGameObjectsWithTag ("Enemy").Length == 0 ) {// AND ESPECIAIS?
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

		//yoda.GetComponent <Stamine> ().setStaminaToKnife (score * 0.00012f);

		//ESCALAR STAMINA !!!!!!!!!
		specialEnemies.GetComponent<RespawnSpecial>().setAmountCagapelados(1);
		// Score
		if (score == nextScorePoint) {
			// Score
			previousScorePoint = score;
			nextScorePoint = nextScorePoint + progressionScore;//(int)Random.Range (nextScorePoint + progressionScore, nextScorePoint + progressionScoreLiberty);
			print ("Next Score: " + nextScorePoint);

			// Pause em point aleatorio?
			pauseHorda = true;
			enemyTeam.GetComponent<Respawn>().setPause(pauseHorda);
			allyTeam.GetComponent<Respawn> ().setPause (pauseHorda);
			specialEnemies.GetComponent<RespawnSpecial>().setPause(pauseHorda);

			//TODO Escalar especiais
			scorePointHastad = Random.Range (previousScorePoint, nextScorePoint);
			print ("Next point to hastad appear: "+ scorePointHastad); 

			scorePointCagapelado = Random.Range (previousScorePoint, nextScorePoint);
			print ("Next point to Cagapelado appear: "+ scorePointCagapelado); 

			scorePointChupinga = Random.Range (previousScorePoint, nextScorePoint);
			print ("Next point to Chupinga appear: "+ scorePointChupinga); 

			int ScoreStep = (nextScorePoint - previousScorePoint); 

			// Enemy Amount
			amountDivisionEnemyIncrease = Random.Range (progressionAmountEnemy, progressionAmountEnemyLiberty);
			stepScoreAmountEnemy = ScoreStep / amountDivisionEnemyIncrease + amountDivisionEnemies;
			amountEnemyInt = 0;
			fortune = fortune + (amountDivisionEnemyIncrease - progressionAmountEnemy) / (progressionAmountEnemyLiberty - progressionAmountEnemy);
			weightFortune = weightFortune + weightAmountEnemy;

			// Move Speed Enemy
			moveSpeedDivisionEnemyIncrease = Random.Range (progressionMoveSpeedEnemy, progressionMoveSpeedEnemyLiberty);
			stepScoreMoveSpeedEnemy = ScoreStep / moveSpeedDivisionEnemyIncrease + moveSpeedDivisionEnemies;
			amountEnemyInt = 0;
			fortune = fortune + (moveSpeedDivisionEnemyIncrease - progressionMoveSpeedEnemy) / (progressionMoveSpeedEnemyLiberty - progressionMoveSpeedEnemy);
			weightFortune = weightFortune + weightMoveSpeed;

			// Attack Enemy
			attackDivisionEnemyIncrease = Random.Range (progressionAttackEnemy, progressionAttackEnemyLiberty);
			stepScoreAttackEnemy = ScoreStep / attackDivisionEnemyIncrease + attackDivisionEnemies;
			attackEnemyInt = 0;
			fortune = fortune + (attackDivisionEnemyIncrease - progressionAttackEnemy) / (progressionAttackEnemyLiberty - progressionAttackEnemy);
			weightFortune = weightFortune + weightAttackEnemy;

			// Ally Amount
			amountDivisionAllyIncrease = Random.Range (progressionAmountAlly, progressionAmountAllyLiberty);
			stepScoreAmountAlly = ScoreStep / amountDivisionAllyIncrease + amountDivisionAllies ;
			amountAllyInt = 0;
			fortune = fortune + (amountDivisionAllyIncrease - progressionAmountAlly) / (progressionAmountAllyLiberty - progressionAmountAlly);
			weightFortune = weightFortune + weightAmountAlly;

			// Move Speed Ally
			moveSpeedDivisionAllyIncrease = Random.Range (progressionMoveSpeedAlly, progressionMoveSpeedAllyLiberty);
			stepScoreMoveSpeedAlly = ScoreStep / moveSpeedDivisionAllyIncrease + moveSpeedDivisionAllies;
			amountAllyInt = 0;
			fortune = fortune + (moveSpeedDivisionAllyIncrease - progressionMoveSpeedAlly) / (progressionMoveSpeedAllyLiberty - progressionMoveSpeedAlly);
			weightFortune = weightFortune + weightMoveSpeedAlly;

			// Attack Ally
			attackDivisionAllyIncrease = Random.Range (progressionAttackAlly, progressionAttackAllyLiberty);
			stepScoreAttackAlly = ScoreStep / attackDivisionAllyIncrease + attackDivisionAllies;
			attackAllyInt = 0;
			fortune = fortune + (attackDivisionAllyIncrease - progressionAttackAlly) / (progressionAttackAllyLiberty - progressionAttackAlly);
			weightFortune = weightFortune + weightAttackAlly;

			fortune = fortune / weightFortune;
			print ("Your fortune is: " + fortune);
		} 

		// Enemy Amount
		if(score >= previousScorePoint + stepScoreAmountEnemy * amountEnemyInt && amountEnemyInt <= amountDivisionEnemyIncrease + amountDivisionEnemies){
			enemyTeam.GetComponent<Respawn> ().plusAmountMinions();
			amountDivisionEnemies++;
			amountEnemyInt++;
			print ("Next Point to plus Enemy: " + (previousScorePoint + stepScoreAmountEnemy * amountEnemyInt));
		}

		// Move Speed Enemy
		if(score == previousScorePoint + stepScoreMoveSpeedEnemy * moveSpeedEnemyInt  && moveSpeedEnemyInt <= moveSpeedDivisionEnemyIncrease + moveSpeedDivisionEnemies ){
			enemyTeam.GetComponent<Respawn> ().plusMoveSpeed();
			moveSpeedDivisionEnemies++;
			moveSpeedEnemyInt++;
			print ("Next Point to plus Enemy Move Speed: " + (previousScorePoint + stepScoreMoveSpeedEnemy * moveSpeedEnemyInt) );
		}

		// Attack Enemy
		if(score == previousScorePoint + stepScoreAttackEnemy * attackEnemyInt  && attackEnemyInt <= attackDivisionEnemyIncrease + attackDivisionEnemies ){
			enemyTeam.GetComponent<Respawn> ().plusAttack();
			attackDivisionEnemies++;
			attackEnemyInt++;
			print ("Next Point to plus Enemy Attack: "+ (previousScorePoint + stepScoreAttackEnemy * attackEnemyInt) );
		}

		// Enemy Ally
		if(score == previousScorePoint + stepScoreAmountAlly * amountAllyInt && amountAllyInt <= amountDivisionAllyIncrease + amountDivisionAllies){
			allyTeam.GetComponent<Respawn> ().plusAmountMinions();
			amountDivisionAllies++;
			amountAllyInt++;
			print ("Next Point to plus Ally: " + (previousScorePoint + stepScoreAmountAlly * amountAllyInt));
		}

		// Move Speed Ally
		if(score == previousScorePoint + stepScoreMoveSpeedAlly * moveSpeedAllyInt  && moveSpeedAllyInt <= moveSpeedDivisionAllyIncrease + moveSpeedDivisionAllies ){
			allyTeam.GetComponent<Respawn> ().plusMoveSpeed();
			moveSpeedDivisionAllies++;
			moveSpeedAllyInt++;
			print ("Next Point to plus Ally Move Speed: " + (previousScorePoint + stepScoreMoveSpeedAlly * moveSpeedAllyInt) );
		}

		// Attack Ally
		if(score == previousScorePoint + stepScoreAttackAlly * attackAllyInt  && attackAllyInt <= attackDivisionAllyIncrease + attackDivisionAllies ){
			allyTeam.GetComponent<Respawn> ().plusAttack();
			attackDivisionAllies++;
			attackAllyInt++;
			print ("Next Point to plus Ally Attack: "+ (previousScorePoint + stepScoreAttackAlly * attackAllyInt) );
		}


		if(score == (int)scorePointHastad){
			specialEnemies.GetComponent<RespawnSpecial>().setAmountHastads(1);
		}

		if(score == (int)scorePointCagapelado){
			specialEnemies.GetComponent<RespawnSpecial>().setAmountCagapelados(1);
		}

		if(score == (int)scorePointChupinga){
			specialEnemies.GetComponent<RespawnSpecial>().setAmountChupingas(1);
		}
	}
		
	public void resetProgression(){
		nextScorePoint = 10;
		previousScorePoint = 10;

		enemyTeam.GetComponent<Respawn>().setAmountMinions(3);
		enemyTeam.GetComponent<Respawn> ().setMoveSpeed (1.0f);
		enemyTeam.GetComponent<Respawn> ().setAttack (25.0f);
		amountDivisionEnemies = 1;
		moveSpeedDivisionEnemies = 1;
		attackDivisionEnemies = 1;

		allyTeam.GetComponent<Respawn>().setAmountMinions(1);
		allyTeam.GetComponent<Respawn> ().setMoveSpeed (1.0f);
		allyTeam.GetComponent<Respawn> ().setAttack (25.0f);
		amountDivisionAllies = 1;
		moveSpeedDivisionAllies = 1;
		attackDivisionAllies = 1;
	}
}
