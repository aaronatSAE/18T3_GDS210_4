using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUi;
	public static bool optionIsVisablePause = false;
	public static bool quitIsVisablePause = false;
	public GameObject optionPause;
	public GameObject quitPause;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) 
			{
				Resume ();
			} else {
				Pause ();
			}
		}
	}
	public void Resume(){
		pauseMenuUi.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		optionPause.SetActive (false);
		optionIsVisablePause = (false);
		quitPause.SetActive (false);
		quitIsVisablePause = (false);
	}
	void Pause(){
		pauseMenuUi.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void OpenOptions()
	{
		if(optionIsVisablePause)
		{
			CloseO();
		}
		else
		{
			VisableO();
		}
	}
	//Set objectto inactive or deactive
	void CloseO(){
		optionPause.SetActive (false);
		optionIsVisablePause = (false);
	}
	void VisableO(){
		optionPause.SetActive (true);
		optionIsVisablePause = true;
	}
	public void OpenQuit()
	{
		if(quitIsVisablePause)
		{
			CloseQ();
		}
		else
		{
			VisableQ();
		}
	}
	void CloseQ()
	{
		quitPause.SetActive (false);
		quitIsVisablePause = (false);
	}
    void VisableQ()
	{
		quitPause.SetActive (true);
		quitIsVisablePause = (true);
	}
}
