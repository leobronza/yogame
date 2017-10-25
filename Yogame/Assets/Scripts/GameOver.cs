using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	GameObject gameOverCanvas;
	private GameObject[] targets;

	void Start () {
		gameOverCanvas = GameObject.FindGameObjectWithTag ("GameOverPanel");
		gameOverCanvas.SetActive (false);
	}

	void Update () {
		
	}

	public void gameOver(){
		gameOverCanvas.SetActive (true);

		targets = GameObject.FindGameObjectsWithTag ("Ally");
		for (int i = 0; i < targets.Length; i++) {
			if (!targets [i].name.Equals ("Nexus")) {
				targets [i].GetComponent<MinionMoviment> ().setPause (true);
			}
		}
		targets = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < targets.Length; i++) {
			targets [i].GetComponent<MinionMoviment> ().setPause (true);
		}

		targets = GameObject.FindGameObjectsWithTag ("Hastad");
		for (int i = 0; i < targets.Length; i++) {
			targets [i].GetComponent<HastadMoviment> ().setPause (true);
		}

		targets = GameObject.FindGameObjectsWithTag ("Cagapelado");
		for (int i = 0; i < targets.Length; i++) {
			targets [i].GetComponent<CagapeladoMoviment> ().setPause (true);
		}


		GameObject.FindGameObjectWithTag ("Yoda").GetComponent<Stamine>().setPause (true);
		this.GetComponent<Touch> ().setPause (true);


		GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<RectTransform>().localPosition = new Vector3 (0, 80, 0);
	}

	public void restartGame(){
		
		gameOverCanvas.SetActive (false);

		targets = GameObject.FindGameObjectsWithTag ("Ally");
		for (int i = 0; i < targets.Length; i++) {
			if (!targets [i].name.Equals ("Nexus")) {
				Destroy (targets [i]);
			} else {
				targets [i].GetComponent<NexusHealth> ().resetHealth ();
			}
		}
		targets = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Hastad");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Cagapelado");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		this.GetComponent<ProgressionController> ().resetProgression ();
		this.GetComponent<Score> ().resetScore ();
		this.GetComponent<Touch> ().setPause (false);
		GameObject.FindGameObjectWithTag ("Yoda").GetComponent<Stamine>().setPause (false);
		GameObject.FindGameObjectWithTag ("Yoda").GetComponent<Stamine>().resetStamina();

		GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<RectTransform>().localPosition = new Vector3 (0, 260, 0);

		this.GetComponent<Touch> ().setZeroCost (false);//TODO retirar
	}

	public void restartGame2(){
		
		gameOverCanvas.SetActive (false);

		targets = GameObject.FindGameObjectsWithTag ("Ally");
		for (int i = 0; i < targets.Length; i++) {
			if (!targets [i].name.Equals ("Nexus")) {
				Destroy (targets [i]);
			} else {
				targets [i].GetComponent<NexusHealth> ().resetHealth ();
			}
		}
		targets = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Hastad");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Cagapelado");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("EnemyAttack");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Hastad");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Cagapelado");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		targets = GameObject.FindGameObjectsWithTag ("Chupinga");
		for (int i = 0; i < targets.Length; i++) {
			Destroy (targets [i]);
		}

		this.GetComponent<ProgressionController> ().resetProgression ();
		this.GetComponent<Score> ().resetScore ();
		this.GetComponent<Touch> ().setPause (false);
		GameObject.FindGameObjectWithTag ("Yoda").GetComponent<Stamine>().setPause (false);
		GameObject.FindGameObjectWithTag ("Yoda").GetComponent<Stamine>().resetStamina();

		GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<RectTransform>().localPosition = new Vector3 (0, 260, 0);

		this.GetComponent<Touch> ().setZeroCost (true); //TODO retirar
	}

	public void exitGame(){
	
	}
}
