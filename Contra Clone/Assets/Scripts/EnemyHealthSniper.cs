using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSniper : EnemyHealth {

    public DestroyableOBJ oilTanker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyLives <= 0)
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
     
            Destroy(gameObject);
            oilTanker.invulnerable = false;
        }
	}


}
