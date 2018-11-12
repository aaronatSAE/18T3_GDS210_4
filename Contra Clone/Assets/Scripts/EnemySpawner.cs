using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject location;
    public int mEnemyCount = 0;
    private float timer = 3.0f;
    public float spawnTimer = 3.0f;
    public GameObject[] mEnemyArray;
    
    

	// Use this for initialization
	void Start () {
        timer = spawnTimer;

    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        Debug.Log(mEnemyCount);
        
        if (timer < 0)
        {                    
            Spawn();
            timer = spawnTimer;
        }

    }

    public void Spawn()
    {
        mEnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (mEnemyArray.Length < 10)
        {
            Instantiate(enemy, location.transform);
            

        }
    }


}
