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
    private bool isDone = true;
    public float walkPointRange;
    private float timer;
    private int randomTime;
    public static bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        setRigidbodyState(true);
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Idle();
        SearchWalkPoint();
        randomTime = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            timer += Time.deltaTime;

            if (randomTime < timer && isDone)
            {
                if (Random.value >= 0.3)
                {
                    if (!walkPointSet) SearchWalkPoint();
                }
                else
                {
                    Idle();
                }
                randomTime = Random.Range(0, 10);
                timer = 0;
            }
            if (!isDone)
            {
                Walk();
            }
        }
        
        

        
    }
    private void Idle()
    {
        //Debug.Log("Idle");
        anim.SetBool("isWalking", false);
        anim.speed = 1;
    }
    private void Walk()
    {
        
        anim.SetBool("isWalking", true);
        anim.speed = (agent.velocity.magnitude /2);

        if (walkPointSet&&!isDead)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 0.2f)
        {
            walkPointSet = false;
            isDone = true;
            Idle();
        }
        else
        {
            isDone = false;
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
            isDone = false;
        }
    }

    void setRigidbodyState(bool state)
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        GetComponent<Animator>().enabled = state;
        GetComponent<NavMeshAgent>().enabled = state;
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
                rigidbody.isKinematic = false;
        }
        Collider[] cols = GetComponentsInChildren<Collider>();
        foreach(Collider col in cols)
        {
            if (col != GetComponent<Collider>()) 
                col.enabled = !state;
        }
        

        GetComponent<Collider>().enabled = state;

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            if (rigidbody != GetComponent<Rigidbody>())
                rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    public void Die()
    {
        isDead = true;
        setRigidbodyState(false);
        Destroy(gameObject, 10);
    }
    public void AddImpact(Vector3 hitPoint, Vector3 impact)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            //rigidbody.AddForceAtPosition(impact*50, hitPoint, ForceMode.Impulse);
            rigidbody.AddForce(-impact * 25,ForceMode.Impulse);
            //rigidbody.AddExplosionForce(1000f, transform.position, 50f);
        }

    }
}
