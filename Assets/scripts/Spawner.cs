 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject agent;
    public float spawnRange;
    private string data;
    // Update is called once per frame
    void Update()
    {
        GameObject[] ias = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKey(KeyCode.N))
        {
            float randomZ = Random.Range(-spawnRange, spawnRange);
            float randomX = Random.Range(-spawnRange, spawnRange);
            var euler = transform.eulerAngles;
            euler.y = Random.Range(0.0f, 360.0f);
            Quaternion rot = Quaternion.Euler(euler);
            Instantiate(agent, new Vector3(randomX, 0, randomZ), rot);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
           
            foreach (GameObject ia in ias)
            {

                ia.GetComponent<AgentScript>().Die();
                ia.GetComponent<AgentScript>().AddImpact(new Vector3(0,0,0), -transform.up*10);
            }
            
        }
        
        data = ias.Length.ToString();
        OnGUI();
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20),"Number of AIs : ");
        GUI.Label(new Rect(120, 10, 100, 20),data);
    }
}
