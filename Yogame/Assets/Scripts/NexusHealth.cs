using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexusHealth : MonoBehaviour {
	public Image fillImg;
	public float maxHealth = 1000f;
	public float curHealth = 0f;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "EnemyAttack") {
			Destroy (other.gameObject);
			damage (75f);
		}
	}


	void Start () {
		curHealth = maxHealth;
	}

	public bool damage(float hit){
		if (curHealth - hit <= 0) {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameOver>().gameOver ();
			//Destroy (gameObject);
			return true;
		} else {
			curHealth -= hit;
			fillImg.fillAmount = curHealth / maxHealth;
			return false;
		}
	}

	public void resetHealth(){
		this.curHealth = this.maxHealth;
		fillImg.fillAmount = curHealth / maxHealth;
	}


}
