﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour {

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        { 
            SceneManager.LoadScene("GameLevel_SW");
        }
    }
}
