using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETeleport : MonoBehaviour {

    public GameObject newPosition;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.position = newPosition.transform.position;
        }
    }
}
