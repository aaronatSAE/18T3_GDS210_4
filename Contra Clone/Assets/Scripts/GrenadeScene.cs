using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScene : EnemyHealth {

    public GameObject grenSniper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(grenSniper == null)
        {
            StartCoroutine("CoExploder");            
        }
	}

    public IEnumerator CoExploder()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
