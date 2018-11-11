using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public static bool optionsAreVisable = false;
	public GameObject optionsUI;
	//public static bool 
		//loadscene
	public void PlayGame()
	{
		SceneManager.LoadScene ("Stephen_");
	}
		//exit
	public void Quit()
	{
		Application.Quit();
	}
	//play credits
	public void Credits()
	{
		SceneManager.LoadScene("Credits_SW");
	}
	//are options active or not?
	public void OpenOptions()
	{
		if(optionsAreVisable)
		{
			Close();
		}
		else
		{
			Visable();
		}
	}
	//Set objectto inactive or deactive
	void Close(){
		optionsUI.SetActive (false);
		optionsAreVisable = false;
	}
	void Visable(){
		optionsUI.SetActive (true);
		optionsAreVisable = true;
	}

	
	
}	