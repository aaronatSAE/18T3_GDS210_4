using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject[] currentLocations; // locations the boss teleports to
    public GameObject[] attackPositions; // locations the attack sphere moves to and from
    [SerializeField] private GameObject hand; // the empty gameobject where the attack sphere is attached to
    public int pos; //determine what position it is
    [SerializeField] private float timeTurn = .5f; // the speed of each action
    [SerializeField] LineRenderer attackLine; //grabs the details from line renderer component
    [SerializeField] private float attack1Speed; //speed of attack 1
    [SerializeField] private float attack2Speed; //speed of attack 2
    [SerializeField] private float attack3Speed; //speed of attack 3
    public float speed = 1; //how fast ball moves in original inumerator
    public GameObject fist; // the attack sphere

    private Animator animator; // creates component slot for this gameobject

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>(); // get animator component from this gameobject
        //Debug.Log("Begin");
        transform.position = currentLocations[0].transform.position; // the starting location of boss battle
        pos = 1; // makes the position corresponding to inital starting position
        DecisionMaker(); // starts decision making system
    }

    // Boss Decision Making System
    public void DecisionMaker()
    {
        //Debug.Log("What to do");
        int rand = Random.Range(0, 3); // Creates a random number between 0-2 to determine decision
        if (rand == 1) // if the number is 1 it goes through to attack phase
        {
            //Debug.Log("which attack");
            if (pos == 1) // Depending on position attack that happens changes
            {
                StartCoroutine("CoAttack1"); // start attack 1
            }
            if (pos == 2)
            {
                StartCoroutine("CoAttack2"); // start attack 1

            }
            if (pos == 3)
            {
                StartCoroutine("CoAttack3"); // start attack 1
            }
        }
        else
        {
            //Debug.Log("move");
            Movement(); // if no attack happens it moves to a different position
        }

    }

    // Boss Movement system
    public void Movement()
    {
        //Debug.Log("where to move");
        int rand2 = Random.Range(0, 3); // Creates a random number between 0-2 to determine decision
        if (rand2 == 0)
        {
            //Debug.Log("position 2");
            transform.position = currentLocations[1].transform.position; // Changes position of boss
            transform.rotation = currentLocations[1].transform.rotation;
            pos = 2; // Makes the position correspond with world position
            DecisionMaker(); // starts decision making system
        }

        if (rand2 == 1)
        {
            //Debug.Log("positon 3");
            transform.position = currentLocations[2].transform.position; // Changes position of boss
            transform.rotation = currentLocations[2].transform.rotation;

            pos = 3; // Makes the position correspond with world position
            DecisionMaker(); // starts decision making system
        }

        if (rand2 == 2)
        {
            //Debug.Log("position 1");
            transform.position = currentLocations[0].transform.position; // Changes position of boss
            transform.rotation = currentLocations[0].transform.rotation;
            pos = 1; // Makes the position correspond with world position
            DecisionMaker(); // starts decision making system
        }
    }

    // Moves an object from a point to another at a cetain speed
    IEnumerator MoveFromTo(Transform objectToMove, Vector3 a, Vector3 b, float speed)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            attackLine.SetPosition(1, objectToMove.transform.position);
            yield return new WaitForFixedUpdate(); // Leave the routine and return here in the next frame
        }
        objectToMove.position = b;
    }

    // Boss's 1st attack pattern
    public IEnumerator CoAttack1()
    {
        animator.SetBool("Attack1 Used", true); // players attack 1 animation, sets parameter true

        Debug.Log("Attack 1 Occurs");
        //fist.transform.position = attackPositions[0].transform.position;
        attackLine.SetPosition(0, hand.transform.position);

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                hand.transform.position,
                attackPositions[0].transform.position,
                attack1Speed)); // starts movefromto ienumerator

        animator.SetBool("Attack1 Used", false); // players attack 1 animation, sets parameter false

        yield return new WaitForSeconds(timeTurn); // waits a certain amount of time before next action

        DecisionMaker(); // starts decision making system
    }

    // Boss's 2nd attack pattern
    public IEnumerator CoAttack2()
    {
        animator.SetBool("Attack2 Used", true); // players attack 2 animation, sets parameter true

        Debug.Log("Attack 2 Occurs");

        attackLine.SetPosition(0, hand.transform.position); // sets the line renderers first point

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                hand.transform.position,
                attackPositions[1].transform.position,
                attack2Speed)); // starts movefromto ienumerator

        attackLine.SetPosition(0, attackPositions[1].transform.position); // sets the line renderers first point

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                attackPositions[1].transform.position,
                attackPositions[2].transform.position,
                attack2Speed)); // starts movefromto ienumerator

        animator.SetBool("Attack2 Used", false); // players attack 2 animation, sets parameter false

        yield return new WaitForSeconds(timeTurn); // waits a certain amount of time before next action

        DecisionMaker(); // starts decision making system
    }

    // Boss's 3rd attack pattern
    public IEnumerator CoAttack3()
    {
        animator.SetBool("Attack3 Used", true); // players attack 3 animation, sets parameter true

        Debug.Log("Attack 3 Occurs");
        attackLine.SetPosition(0, attackPositions[10].transform.position); // sets the line renderers first point

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                attackPositions[10].transform.position,
                attackPositions[3].transform.position,
                attack3Speed)); // starts movefromto ienumerator

        transform.position = currentLocations[3].transform.position; // changes boss position for attack 3 pattern
        attackLine.SetPosition(0, attackPositions[9].transform.position); // sets the line renderers first point

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                attackPositions[9].transform.position,
                attackPositions[4].transform.position,
                attack3Speed)); // starts movefromto ienumerator

        transform.position = currentLocations[4].transform.position; // changes boss position for attack 3 pattern
        attackLine.SetPosition(0, attackPositions[8].transform.position); // sets the line renderers first point

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                attackPositions[8].transform.position,
                attackPositions[5].transform.position,
                attack3Speed)); // starts movefromto ienumerator

        transform.position = currentLocations[5].transform.position; // changes boss position for attack 3 pattern
        attackLine.SetPosition(0, attackPositions[7].transform.position); // sets the line renderers first point

        yield return StartCoroutine(
            MoveFromTo(
                fist.transform,
                attackPositions[7].transform.position,
                attackPositions[6].transform.position,
                attack3Speed)); // starts movefromto ienumerator

        animator.SetBool("Attack3 Used", false); // players attack 3 animation, sets parameter false

        yield return new WaitForSeconds(timeTurn); // waits a certain amount of time before next action

        DecisionMaker(); // starts decision making system
    }

}
