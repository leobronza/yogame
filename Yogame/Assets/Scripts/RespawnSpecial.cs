using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpecial : MonoBehaviour {

	//public List<GameObject> hastads;
	private GameObject hastadNew;
	public GameObject modelHastad;
	public float amountHastads = 0; //TODO change to private
	private float moveSpeedHastad = 2.0f;
	private Vector3 hastadDestination;
	private float attackHastad = 50f;

	GameObject cagapeladoNew;
	public GameObject modelCagapelado;
	public float amountCagapelados = 0; //TODO change to private
	private float moveSpeedCagapelado = 2.0f;
	private Vector3 CagapeladoDestination;
	private float attackCagapelado = 50f;


	private bool pause =  false;
	void Start () {
	}

	void Update () {
		if (!pause) {
			for (int i = 0; i < (int)amountHastads; i++) {
				hastadDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (1, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (hastadDestination, 0.49f)) {
					hastadNew = Instantiate (modelHastad, hastadDestination, Quaternion.identity, this.transform);
					hastadNew.GetComponent<HastadMoviment> ().setMoveSpeed (moveSpeedHastad);
					hastadNew.GetComponent<HastadMoviment> ().setAttack (attackHastad);
					amountHastads--;
				}
			}
		
			for (int i = 0; i < (int)amountCagapelados; i++) {
				CagapeladoDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (1, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (CagapeladoDestination, 0.49f)) {
					cagapeladoNew = Instantiate (modelCagapelado, CagapeladoDestination, Quaternion.identity, this.transform);
					//cagapeladoNew.GetComponent<CagapeladoMoviment> ().setMoveSpeed (moveSpeedCagapelado);
					//cagapeladoNew.GetComponent<CagapeladoMoviment> ().setAttack (attackCagapelado);
					amountCagapelados--;
				}
			}

		}
	}

	// Amount
	public void plusAmountHastads(){
		this.amountHastads += 0.1f;
	}

	public void setAmountHastads(float amountHastads){
		this.amountHastads = amountHastads;
	}

	// Move Speed
	public void plusMoveSpeedHastad(){
		this.moveSpeedHastad += 0.1F;
	}

	public void setMoveSpeedHastad(float moveSpeedHastad){
		this.moveSpeedHastad = moveSpeedHastad;
	}

	// Attack
	public void plusAttackHastad(){
		this.attackHastad += 1;
	}

	public void setAttackHastad(float attackHastad){
		this.attackHastad = attackHastad;
	}


	// Amount
	public void plusAmountCagapelados(){
		this.amountCagapelados += 0.1f;
	}

	public void setAmountCagapelados(float amountCagapelados){
		this.amountCagapelados = amountCagapelados;
	}

	// Move Speed
	public void plusMoveSpeedCagapelado(){
		this.moveSpeedCagapelado += 0.1F;
	}

	public void setMoveSpeedCagapelado(float moveSpeedCagapelado){
		this.moveSpeedCagapelado = moveSpeedCagapelado;
	}

	// Attack
	public void plusAttackCagapelado(){
		this.attackCagapelado += 1;
	}

	public void setAttackCagapelado(float attackCagapelado){
		this.attackCagapelado = attackCagapelado;
	}




	public void setPause(bool pause){
		this.pause = pause;
	}
}
