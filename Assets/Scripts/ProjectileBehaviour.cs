using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    public float destroyTimer = 5f ;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, destroyTimer);
        }
    }
}
