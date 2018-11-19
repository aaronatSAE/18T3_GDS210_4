using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public GameObject[] currentLocations;
    public int pos;
    public float timeTurn = 3f;

	// Use this for initialization
	void Start () {
        transform.position = currentLocations[0].transform.position;
        pos = 1;
	}

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DecisionMaker()
    {       
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            if(pos == 1)
            {
                StartCoroutine("CoAttack1");
            }
            if (pos == 2)
            {
                StartCoroutine("CoAttack2");
                
            }
            if (pos == 3)
            {
                StartCoroutine("CoAttack3");
            }
        }
        else
        {
            Movement(); 
        }

    }


    public void Movement()
    {
        int rand2 = Random.Range(0, 3);
        if (rand2 == 0)
        {
            transform.position = currentLocations[1].transform.position;
            pos = 2;
            DecisionMaker();
        }

        if (rand2 == 1)
        {
            transform.position = currentLocations[2].transform.position;
            pos = 3;
            DecisionMaker();
        }

        if (rand2 == 2)
        {
            transform.position = currentLocations[0].transform.position;
            pos = 1;
            DecisionMaker();
        }
    }

    public IEnumerator CoAttack1()
    {
        Debug.Log("Attack 1 Occurs");
        yield return new WaitForSeconds(2f);
        DecisionMaker();
    }

    public IEnumerator CoAttack2()
    {
        Debug.Log("Attack 2 Occurs");
        yield return new WaitForSeconds(2f);
        DecisionMaker();
    }

    public IEnumerator CoAttack3()
    {
        Debug.Log("Attack 3 Occurs");
        yield return new WaitForSeconds(2f);
        DecisionMaker();
    }

}
