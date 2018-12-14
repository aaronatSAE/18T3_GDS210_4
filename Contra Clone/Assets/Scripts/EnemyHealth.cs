using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int enemyLives = 1;
    public GameObject explosionParticle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyLives <= 0)
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
           
            Destroy(gameObject);
        }
	}


}
