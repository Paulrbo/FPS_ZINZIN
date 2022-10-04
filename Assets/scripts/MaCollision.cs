using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class MaCollision : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cible"))
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject,2f);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("IA"))
        {
            Vector3 impactDirection = (collision.transform.position- transform.position).normalized;
            //Debug.Log("kill");
            
            collision.gameObject.GetComponent<AgentScript>().Die();
            ContactPoint contact = collision.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            
            collision.gameObject.GetComponent<AgentScript>().AddImpact(pos,impactDirection);
        }
        Destroy(gameObject);

    }
    private void Update()
    {
        Destroy(gameObject, 10);
    }
}