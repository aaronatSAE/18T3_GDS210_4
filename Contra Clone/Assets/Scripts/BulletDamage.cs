using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    public int damage = 1;
    public bool checker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Senemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().enemyLives -= damage;
            Destroy(gameObject);

        }
        
        
    }
  
    
}
