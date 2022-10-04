using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public Vector3 walkPoint;
    private bool walkPointSet = false;
    public float walkPointRange;
    private float timer;
    private int randomTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", false);

        randomTime = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (randomTime < timer && walkPointSet)
        {
            if (Random.value >= 0.2)
            {
                Walk();
            }
            else
            {
                Idle();
            }
            randomTime = Random.Range(0, 10);
            timer = 0;
        }
        //Debug.Log(randomTime + " " + timer);
        
        Debug.Log(anim.speed + "  " + agent.velocity);

        
    }
    private void Idle()
    {
       // walkPoint = transform.position;
        //walkPointSet = true;
        anim.SetBool("isWalking", false);
        anim.speed = 1;
    }
    private void Walk()
    {
        anim.SetBool("isWalking", true);
        anim.speed = agent.velocity / 2;

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
            

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f))
        {
            walkPointSet = true;
            //Idle();
        }
            
    }
}
