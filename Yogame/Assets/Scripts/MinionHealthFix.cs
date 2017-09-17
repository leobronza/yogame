using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealthFix : MonoBehaviour {

	Quaternion rotation;
	Vector3 position;
	void Awake()
	{
		rotation = transform.rotation;
		position = transform.parent.position - transform.position;

	}
	void LateUpdate()
	{
		transform.rotation = rotation;
		transform.position = transform.parent.position - position;
	
	}
}
