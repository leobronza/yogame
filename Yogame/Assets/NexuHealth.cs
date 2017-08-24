using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexuHealth : MonoBehaviour {
	public Image fillImg;
	public float max_Health = 1000f;
	public float cur_Health = 0f;
	// Use this for initialization
	void Start () {
		cur_Health = max_Health;
	}

	public bool damage(float hit){
		if (cur_Health - hit <= 0) {
			Destroy (gameObject);
			return true;
		} else {
			cur_Health -= hit;
			fillImg.fillAmount = cur_Health / max_Health;
			return false;
		}
	}


}
