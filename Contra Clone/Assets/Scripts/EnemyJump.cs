using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {

    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * speed);

        }

        
    }
}
