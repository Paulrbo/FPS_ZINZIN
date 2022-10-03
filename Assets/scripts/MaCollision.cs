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
    }
}