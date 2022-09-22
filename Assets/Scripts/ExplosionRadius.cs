using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject;
        }
        if(other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = null;
         }
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }
}
