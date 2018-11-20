using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public GameObject[] currentLocations;
    public int pos;
    public float timeTurn = 3f;
    public GameObject[] attackPositions;
    [SerializeField] LineRenderer attackLine;
    public float speed = 1;
    public GameObject fist;

	// Use this for initialization
	void Start () {
        Debug.Log("Begin");
        transform.position = currentLocations[0].transform.position;
        pos = 1;
        DecisionMaker();
	}

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DecisionMaker()
    {
        Debug.Log("What to do");
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            Debug.Log("which attack");
            if (pos == 1)
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
            Debug.Log("move");
            Movement(); 
        }

    }


    public void Movement()
    {
        Debug.Log("where to move");
        int rand2 = Random.Range(0, 3);
        if (rand2 == 0)
        {
            Debug.Log("position 2");
            transform.position = currentLocations[1].transform.position;
            pos = 2;
            DecisionMaker();
        }

        if (rand2 == 1)
        {
            Debug.Log("positon 3");
            transform.position = currentLocations[2].transform.position;
            pos = 3;
            DecisionMaker();
        }

        if (rand2 == 2)
        {
            Debug.Log("position 1");
            transform.position = currentLocations[0].transform.position;
            pos = 1;
            DecisionMaker();
        }
    }

    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            attackLine.SetPosition(1, objectToMove.transform.position);
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        objectToMove.position = b;
    }

    public IEnumerator CoAttack1()
    {
        Debug.Log("Attack 1 Occurs");
        //fist.transform.position = attackPositions[0].transform.position;
        attackLine.SetPosition(0, transform.position);
        yield return StartCoroutine(MoveFromTo(fist.transform, transform.position, attackPositions[0].transform.position,20f));
        
   

        yield return new WaitForSeconds(0.5f);

        DecisionMaker();
    }

    public IEnumerator CoAttack2()
    {
        Debug.Log("Attack 2 Occurs");
        attackLine.SetPosition(0, transform.position);
        yield return StartCoroutine(MoveFromTo(fist.transform, transform.position, attackPositions[1].transform.position, 20f));



        yield return new WaitForSeconds(2f);
        DecisionMaker();
    }

    public IEnumerator CoAttack3()
    {
        Debug.Log("Attack 3 Occurs");
        attackLine.SetPosition(0, transform.position);
        yield return StartCoroutine(MoveFromTo(fist.transform, transform.position, attackPositions[3].transform.position, 20f));


        yield return new WaitForSeconds(2f);
        DecisionMaker();
    }

}
