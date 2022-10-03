using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonShoot : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private GameObject prefab;
    
    // Start is called before the first frame update

    /*private void Start()
    {
        StartCoroutine(SpawnMunitions());
    }*/
    
    public void SpawnMunition()
    {
        //j'instancie la balle
        GameObject munition = Instantiate(prefab,
            cameraTransform.position,
            cameraTransform.rotation);
        
        //je récupère son rigidBody
        Rigidbody munitionRigidbody = munition.GetComponent<Rigidbody>();
        
        //j'applique une force initiale à la balle
        munitionRigidbody.AddForce(cameraTransform.forward * 10000f);
    }

    private IEnumerator SpawnMunitions()
    {
        while (true)
        {
            SpawnMunition();

            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnMunition();
        }
    }
}
