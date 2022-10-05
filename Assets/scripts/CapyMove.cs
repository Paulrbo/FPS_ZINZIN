using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapyMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 walkPoint;
    private bool walkPointSet = false;
    //private bool isDone = true;
    public float walkPointRange;
    //private float timer;
    //private int randomTime;
    //public static bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Walk();
    }
    private void Walk()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Debug.Log("is comming");
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 0.2f)
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
        }
    }
}
