using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {


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
	public void Credits()
	{
		SceneManager.LoadScene("Credits_SW");
	}
	public void OpenOptions(){}
}	