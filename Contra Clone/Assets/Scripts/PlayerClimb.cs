using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour {

    //public Rigidbody handRB;
    public bool check;
    

    // Use this for initialization
    void Start ()
    {
        //handRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        Debug.Log("something");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bar")
        {
            Debug.Log("onBar");
            check = true;
            //sets the quad collider of the bar on
            other.transform.GetChild(0).gameObject.SetActive(true);
            //toggles the players onBar state on
            GetComponentInParent<PlayerMovement>().onBar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bar")
        {
            check = false;

            //sets the quad collider of the bar off
            other.transform.GetChild(0).gameObject.SetActive(false);
            //toggles the players onBar state off
            GetComponentInParent<PlayerMovement>().onBar = false;
        }
    }   
}
