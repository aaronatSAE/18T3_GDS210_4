using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour {
	//skip credits
	public void skipCredits()
	{
		SceneManager.LoadScene ("Main_Menu_SW");
	}
	//
	public void skipCutscene()
	{
		SceneManager.LoadScene ("Stephen_");
	}
	
}
