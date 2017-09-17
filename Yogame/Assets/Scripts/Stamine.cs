using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamine : MonoBehaviour {
	
	public float maximumStamina = 1.0f;
	public float currentStamina;
	private float staminaToKnife = 0.1f;
	private float staminaToRotation = 0.25f;
	public GameObject staminaBar;
	public bool pause = false;

	void Start () {
		currentStamina = maximumStamina - staminaToKnife ;
	}
		
	void Update () {
		if (!pause) {
			if (currentStamina < maximumStamina) {
				currentStamina += 0.2f * Time.deltaTime;
				updateStamina ();
			}
		}
	}
		
	private void updateStamina(){
		staminaBar.transform.localScale = new Vector3(currentStamina,staminaBar.transform.localScale.y,staminaBar.transform.localScale.z);
	}

	public bool chekStaminaKnife(){
		return currentStamina >= staminaToKnife;
	}

	public bool chekStaminaRotation(){
		return currentStamina >= staminaToRotation;
	}

	public void decreaseStaminaKnife(){
		currentStamina -= staminaToKnife;
		updateStamina();
	}

	public void decreaseStaminaRotation(){
		currentStamina -= staminaToRotation;
		updateStamina();
	}

	public void setPause(bool pause){
		this.pause = pause;
	}

	public void resetStamina(){
		this.currentStamina = maximumStamina - staminaToKnife ;
		updateStamina ();
	}

}
