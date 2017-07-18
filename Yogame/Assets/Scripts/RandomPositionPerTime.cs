using UnityEngine;

public class RandomPositionPerTeam{
	// 0 => FriendTeam
	// 1 => EnemyTeam
	public Vector2 getRandomPositionPerTeam(int team, float sizeToRide){
		float backGroundLocalScaleX = GameObject.FindGameObjectWithTag("BackGround").transform.localScale.x/2;
		float backGroundLocalScaleY = GameObject.FindGameObjectWithTag("BackGround").transform.localScale.y/2;

		if (team == 0) {
			if (new RandomEdgePerTeam ().getRandomEdgePerTeam () == 0)
				return new Vector2 (-backGroundLocalScaleX-sizeToRide,  Random.Range(0, backGroundLocalScaleY));
			return new Vector2 (Random.Range(-backGroundLocalScaleX, backGroundLocalScaleX), backGroundLocalScaleY+sizeToRide); 

		} else {
			if (new RandomEdgePerTeam ().getRandomEdgePerTeam () == 0)
				return new Vector2 (
					Random.Range (-backGroundLocalScaleX, backGroundLocalScaleX), 
					-backGroundLocalScaleY-sizeToRide
				);
			return new Vector2 (backGroundLocalScaleX+sizeToRide, Random.Range (-backGroundLocalScaleY, 0));
		}
			
	}


}
