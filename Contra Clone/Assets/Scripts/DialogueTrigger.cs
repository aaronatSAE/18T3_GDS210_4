using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public GameObject dBox;
	public GameObject dTrigger;
	
	public void OnTriggerEnter(Collider  col)
	{
		//print("hello");
		
		if(col.tag == "Player")
		{
			Debug.Log("yes");
			DisplayD();
		}
	}
	void DisplayD()
	{			
		dBox.SetActive (true);
		Destroy(dTrigger);
	}
}
