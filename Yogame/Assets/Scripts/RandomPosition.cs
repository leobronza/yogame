using UnityEngine;

public class RandomPosition  {
	
	public Vector3 getRandomPosition(float margin, float heightFloor, float lateralLimiter){
		float backGroundLocalScaleX = GameObject.FindGameObjectWithTag("BackGround").transform.localScale.x/2*10;
		float backGroundLocalScaleZ = GameObject.FindGameObjectWithTag("BackGround").transform.localScale.z/2*10;

		int randomScreenSide = new RandomScreenSide ().getRandomScreenSide ();
		if (randomScreenSide == 0) {
			return new Vector3 (-backGroundLocalScaleX+margin, heightFloor, Random.Range(-backGroundLocalScaleZ+margin, lateralLimiter));
		} else if (randomScreenSide == 1) {
			return new Vector3 (backGroundLocalScaleX-margin, heightFloor, Random.Range(-backGroundLocalScaleZ+margin, lateralLimiter));
		} else {
			return new Vector3 (Random.Range(-backGroundLocalScaleX, backGroundLocalScaleX), heightFloor, -backGroundLocalScaleZ+margin);
		}
	}
}
