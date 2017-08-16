using UnityEngine;

public class RandomPositionPerTeam{
	// 0 => FriendTeam
	// 1 => EnemyTeam
	public Vector3 getRandomPositionPerTeam(int team, float borderSize, string backGroundTag, float heightFloor){
		float backGroundLocalScaleX = GameObject.FindGameObjectWithTag(backGroundTag).transform.localScale.x/2*10;
		float backGroundLocalScaleZ = GameObject.FindGameObjectWithTag(backGroundTag).transform.localScale.z/2*10;

		if (team == 0) {
			if (new RandomEdgePerTeam ().getRandomEdgePerTeam () == 0)
				return new Vector3 (-backGroundLocalScaleX+borderSize, heightFloor ,Random.Range(0, 2.0f));
			return new Vector3 (Random.Range(-0.03f, backGroundLocalScaleX), heightFloor , backGroundLocalScaleZ-borderSize); 

		} else {
			if (new RandomEdgePerTeam ().getRandomEdgePerTeam () == 0)
				return new Vector3 (Random.Range (-backGroundLocalScaleX, backGroundLocalScaleX), heightFloor ,-backGroundLocalScaleZ+borderSize);
			return new Vector3 (backGroundLocalScaleX-borderSize, heightFloor , Random.Range (-backGroundLocalScaleZ, 0));
		}
			
	}


}
