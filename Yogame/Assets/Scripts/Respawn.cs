using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public List<GameObject> minions;
	public GameObject modelMinion;
	public int amountMinions = 4; //TODO change to private
	public int team; 
	private float moveSpeed = 1.0f;
	private Vector3 minionDestination;

	void Start () {
		minions = new List<GameObject>();
		for(int i = 0 ; i < amountMinions ;i ++){
			minions.Add (null);
			minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
			if (!Physics.CheckSphere (minionDestination, 0.49f)) {
				minions.Insert(i, Instantiate (modelMinion, minionDestination, Quaternion.identity, this.transform));
				//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
				minions[i].GetComponent<MinionMoviment>().setMoveSpeed(moveSpeed);
			}
		}
	}

	void Update () {
		for (int i = 0; i < amountMinions; i++) {
			if (i >= minions.Count) {
					minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (minionDestination, 0.49f)) {
					minions.Insert(i, Instantiate (modelMinion, minionDestination, Quaternion.identity, this.transform));
					//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
					minions[i].GetComponent<MinionMoviment>().setMoveSpeed(moveSpeed);
				}
			} 
			else if (minions [i] == null) {
				minions.Add (null);
				minionDestination = new RandomPositionPerTeam ().getRandomPositionPerTeam (team, 0.5F, "BackGround", 0.02F);
				if (!Physics.CheckSphere (minionDestination, 0.49f)) {
					minions [i] = Instantiate (modelMinion, minionDestination, Quaternion.identity, this.transform);
					//enemies [i].transform.LookAt (new Vector3 (0f, 0.02f, 0f));
					minions[i].GetComponent<MinionMoviment>().setMoveSpeed(moveSpeed);
				}

			}
		}
	}

	public void plusAmountMinions(){
		this.amountMinions++;
	}

	public void setAmountMinions(int amountMinions){
		this.amountMinions = amountMinions;
	}

	public void plusMoveSpeed(){
		this.moveSpeed += 0.2F;
	}

	public void setMoveSpeed(float moveSpeed){
		this.moveSpeed = moveSpeed;
	}
}
