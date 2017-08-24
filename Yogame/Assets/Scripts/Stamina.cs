using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {
	
	public float maximumStamina = 1.0f;
	public float currentStamina;
	private float staminaToKnife = 0.2f;
	public GameObject staminaBar;

	void Start () {
		currentStamina = maximumStamina;
	}
		
	void Update () {
		if (currentStamina < maximumStamina) {
			currentStamina += 0.2f * Time.deltaTime;
			updateStamina();
		}
	}
		
	private void updateStamina(){
		staminaBar.transform.localScale = new Vector3(currentStamina,staminaBar.transform.localScale.y,staminaBar.transform.localScale.z);
	}

	public bool chekStaminaKnife(){
		return currentStamina >= 0.2f;
	}

	public void decreaseStaminaKnife(){
		currentStamina -= staminaToKnife;
		updateStamina();
	}




}
