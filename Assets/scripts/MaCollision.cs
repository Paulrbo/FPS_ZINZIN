using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mur"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Collision");
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Cible"))
        {
            Destroy(collision.gameObject);
        }
    }
}