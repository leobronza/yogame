using UnityEngine;

public class RandomEdgePerTeam {
	
	// 0 => borda esquerda ou inferior
	// 1 => borda direita ou superior
	public int getRandomEdgePerTeam(){
		return Random.Range (0, 2);
	}

}
