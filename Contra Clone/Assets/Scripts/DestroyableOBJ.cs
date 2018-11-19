using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableOBJ : MonoBehaviour {

    public GameObject keySniperEnemy;
    public int enemyLives = 20;
    public bool invulnerable = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pBullet"))
        {
            if (invulnerable == false)
            {
                int bulletdamage = other.gameObject.GetComponent<BulletDamage>().damage;
                enemyLives -= bulletdamage;
                
                if (enemyLives <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
