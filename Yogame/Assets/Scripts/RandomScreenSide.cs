using UnityEngine;

public class RandomScreenSide {

	// 0 => Left Side
	// 1 => Right Side
	// 2 => Bottom Side
	public int getRandomScreenSide(){
		return Random.Range (0, 3);
	}
		
}
