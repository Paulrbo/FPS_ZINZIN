using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject agent;
    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            float randomZ = Random.Range(-spawnRange, spawnRange);
            float randomX = Random.Range(-spawnRange, spawnRange);
            var euler = transform.eulerAngles;
            euler.y = Random.Range(0.0f, 360.0f);
            Quaternion rot = Quaternion.Euler(euler);
            Instantiate(agent, new Vector3(randomX, 0, randomZ), rot);
        }
    }
}
