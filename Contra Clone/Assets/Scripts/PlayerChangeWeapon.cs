using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeWeapon : MonoBehaviour {

    private bool weaponSwap = true;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponSwap = !weaponSwap;
            transform.GetChild(0).gameObject.SetActive(weaponSwap);
            transform.GetChild(1).gameObject.SetActive(!weaponSwap);
        }
	}
}
