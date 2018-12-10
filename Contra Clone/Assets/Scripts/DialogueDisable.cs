using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisable : MonoBehaviour {

	public float duration;
	//Destroy Cutscenes
	void Start()
	{
		Destroy (gameObject, duration);
	}
}
