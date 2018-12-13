using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour {

    //this script is to be attached to all climbing bars    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand")
        {
            //sets the quad collider of the bar on
            transform.GetChild(0).gameObject.SetActive(true);
            //toggles the players onBar state on
            other.gameObject.transform.GetComponentInParent<PlayerMovement>().onBar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerHand")
        {
            //sets the quad collider of the bar off
            transform.GetChild(0).gameObject.SetActive(false);
            //toggles the players onBar state off
            other.gameObject.transform.GetComponentInParent<PlayerMovement>().onBar = false;
        }
    }
}
