using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public GameObject[] currentLocations; // locations the boss teleports to
    public GameObject[] attackPositions; // locations the attack sphere moves to and from
    [SerializeField] private GameObject hand; // the empty gameobject where the attack sphere is attached to
    public int pos; //determine what position it is
   
    [SerializeField] LineRenderer attackLine;
    [SerializeField] private float attack1Speed;
    [SerializeField] private float attack2Speed;
    [SerializeField] private float attack3Speed;
    public float speed = 1;
    public GameObject fist;

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
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
        int rand = Random.Range(0, 3);
        if(rand == 1)
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
        if (rand2 == 0 )
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
        animator.SetBool("Attack1 Used", true);

        Debug.Log("Attack 1 Occurs");
        //fist.transform.position = attackPositions[0].transform.position;
        attackLine.SetPosition(0, hand.transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                hand.transform.position, 
                attackPositions[0].transform.position,
                attack1Speed));

        animator.SetBool("Attack1 Used", false);

        yield return new WaitForSeconds(0.5f);

        //begins next decision
        DecisionMaker();
    }

    public IEnumerator CoAttack2()
    {
        animator.SetBool("Attack2 Used", true);

        Debug.Log("Attack 2 Occurs");

        attackLine.SetPosition(0, hand.transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                hand.transform.position, 
                attackPositions[1].transform.position, 
                attack2Speed));

        attackLine.SetPosition(0, attackPositions[1].transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                attackPositions[1].transform.position, 
                attackPositions[2].transform.position, 
                attack2Speed));

        animator.SetBool("Attack2 Used", false);

        yield return new WaitForSeconds(0.5f);

        //begins next decision
        DecisionMaker();
    }

    public IEnumerator CoAttack3()
    {
        animator.SetBool("Attack3 Used", true);

        Debug.Log("Attack 3 Occurs");
        attackLine.SetPosition(0, attackPositions[10].transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                attackPositions[10].transform.position, 
                attackPositions[3].transform.position, 
                attack3Speed));

        transform.position = currentLocations[3].transform.position;
        attackLine.SetPosition(0, attackPositions[9].transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                attackPositions[9].transform.position, 
                attackPositions[4].transform.position,
                attack3Speed));

        transform.position = currentLocations[4].transform.position;
        attackLine.SetPosition( 0, attackPositions[8].transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                attackPositions[8].transform.position,
                attackPositions[5].transform.position,
                attack3Speed));

        transform.position = currentLocations[5].transform.position;
        attackLine.SetPosition(0, attackPositions[7].transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform, 
                attackPositions[7].transform.position, 
                attackPositions[6].transform.position,
                attack3Speed));

        animator.SetBool("Attack3 Used", false);

        yield return new WaitForSeconds(0.5f);

        //begins next decision
        DecisionMaker();
    }

}
