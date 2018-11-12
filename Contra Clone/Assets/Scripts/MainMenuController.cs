using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public static bool optionsAreVisable = false;
	public GameObject optionsUI;
	public static bool optionIsVisable = false;
	public static bool helpIsVisable = false;
	public GameObject option;
	public GameObject help;
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
	public void Options()
	{
		if(optionIsVisable)
		{
			OptionClose();
		}
		else
		{
			OptionVisable();
		}
	}
	
	public void OptionClose()
	{
		option.SetActive (false);
		optionIsVisable = (false);
		help.SetActive (false);
		helpIsVisable = (false);
	}
	
	public void OptionVisable()
	{
		option.SetActive (true);
		optionIsVisable = (true);
		help.SetActive (false);
		helpIsVisable = (false);
	}
	
	public void Help()
	{
		if(helpIsVisable)
		{
			HelpClose();
		}
		else
		{
			HelpVisable();
		}
	}
	public void HelpClose()
	{
		option.SetActive (false);
		optionIsVisable = (false);
		help.SetActive (false);
		helpIsVisable = (false);
	}
	public void HelpVisable()
	{
		option.SetActive (false);
		optionIsVisable = (false);
		help.SetActive (true);
		helpIsVisable = (true);		
	}
}	