using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public List<GameObject> minions;
	public GameObject modelMinion;
	public float amountMinions = 1; //TODO change to private
	public int team; 
	private float moveSpeed = 1.0f;
	private Vector3 minionDestination;
	private float attack;

	void Start () {
		minions = new List<GameObject>();
		for(int i = 0 ; i < (int)amountMinions ;i ++){
			minions.Add (null);
			minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
			if (!Physics.CheckSphere (minionDestination, 0.49f)) {
				minions.Insert(i, Instantiate (modelMinion, minionDestination, Quaternion.identity, this.transform));
				//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
				minions[i].GetComponent<MinionMoviment>().setMoveSpeed(moveSpeed);
				minions[i].GetComponent<MinionMoviment>().setAttack(attack);
			}
		}
	}

	void Update () {
		for (int i = 0; i < (int)amountMinions; i++) {
			if (i >= minions.Count) {
					minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (minionDestination, 0.49f)) {
					minions.Insert(i, Instantiate (modelMinion, minionDestination, Quaternion.identity, this.transform));
					//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
					minions[i].GetComponent<MinionMoviment>().setMoveSpeed(moveSpeed);
					minions[i].GetComponent<MinionMoviment>().setAttack(attack);
				}
			} 
			else if (minions [i] == null) {
				minions.Add (null);
				minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (minionDestination, 0.49f)) {
					minions [i] = Instantiate (modelMinion, minionDestination, Quaternion.identity, this.transform);
					//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
					minions[i].GetComponent<MinionMoviment>().setMoveSpeed(moveSpeed);
					minions[i].GetComponent<MinionMoviment>().setAttack(attack);
				}

			}
		}
	}

	// Amount
	public void plusAmountMinions(){
		this.amountMinions += 0.1f;
	}

	public void setAmountMinions(float amountMinions){
		this.amountMinions = amountMinions;
	}

	// Move Speed
	public void plusMoveSpeed(){
		this.moveSpeed += 0.1F;
	}

	public void setMoveSpeed(float moveSpeed){
		this.moveSpeed = moveSpeed;
	}

	// Attack
	public void plusAttack(){
		this.attack += 1;
	}

	public void setAttack(float attack){
		this.attack = attack;
	}

}
