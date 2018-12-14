using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeat : MonoBehaviour {

	public void OnDestroy()
	{
		SceneManager.LoadScene("Main_Menu_SW");
	}
}
