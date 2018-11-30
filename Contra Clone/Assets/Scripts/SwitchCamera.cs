using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

	public GameObject cameraOne;
	public GameObject cameraTwo;
	public GameObject Trigger;
	
	public void OnTriggerEnter(Collider  col)
	{
		print("hello");
		
		if(col.tag == "Player")
		{
			Debug.Log("yes");
			Switch();
		}
	}
	void Switch()
	{			
		cameraOne.SetActive (false);
		cameraTwo.SetActive (true);
		Destroy(Trigger);
	}
}
