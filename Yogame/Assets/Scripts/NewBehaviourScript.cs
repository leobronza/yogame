using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject[] gameObjects;
	public GameObject Enemy;
	public GameObject Chupinga;


	void Start () {
		gameObjects = new GameObject[5];
		for(int i = 0 ; i < 5 ;i++){
			gameObjects[i] = Instantiate(Enemy, new RandomPositionPerTeam().getRandomPositionPerTeam(1,  0.33F), Quaternion.identity);

			float degree = Mathf.Atan2 (gameObjects[i].transform.localPosition.y - GameObject.FindGameObjectWithTag("Chupinga").transform.localPosition.y, gameObjects[i].transform.localPosition.x - GameObject.FindGameObjectWithTag("Chupinga").transform.localPosition.x)*Mathf.Rad2Deg;
			gameObjects[i].transform.rotation = Quaternion.Euler (0.0f, 0.0f, degree);
		} 

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 5; i++) {
			float degree = Mathf.Atan2 (gameObjects[i].transform.localPosition.y - GameObject.FindGameObjectWithTag("Chupinga").transform.localPosition.y, gameObjects[i].transform.localPosition.x - GameObject.FindGameObjectWithTag("Chupinga").transform.localPosition.x)*Mathf.Rad2Deg;
			//gameObjects[i].transform.rotation = Quaternion.Euler (0.0f, 0.0f, degree);

			gameObjects[i].transform.rotation = Quaternion.Slerp(gameObjects[i].transform.rotation, Quaternion.AngleAxis(degree, new Vector3(0,0,1)), Time.deltaTime * 1.0f);

			//if (gameObjects [i].transform.position != GameObject.FindGameObjectWithTag ("Chupinga").transform.position)
				gameObjects [i].transform.position += new Vector3 (GameObject.FindGameObjectWithTag ("Chupinga").transform.position.x - gameObjects [i].transform.position.x,
				GameObject.FindGameObjectWithTag ("Chupinga").transform.position.y - gameObjects [i].transform.position.y, 0).normalized * Time.deltaTime * 1f;
		
		}
				
		if(Input.touchCount > 0 ){
			Vector3 touch = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 0));
		Chupinga.transform.position = 
				Vector2.Lerp (GameObject.FindGameObjectWithTag ("Chupinga").transform.position, touch, Time.deltaTime);
		}
		//GameObject.FindGameObjectWithTag("Chupinga").transform.position = new RandomPosition().getRandomPosition(0,  0.33F);
	}
}
