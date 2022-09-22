using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bomb;
    private Rigidbody enemtRb;
    private Transform player;
    private float enemySpeed;
    private GameObject bombPrefab;
    void Start()
    {
        enemtRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        enemySpeed = 3;
        InvokeRepeating("ThrowBomb", 1, 6);
    }

   
    void Update()
    {
        transform.LookAt(player);
        transform.Translate(Vector3.forward * Time.deltaTime*enemySpeed);
        
    }
   void ThrowBomb()
    {
        bombPrefab = bombPrefab = Instantiate(bomb, transform.position + new Vector3(0, 3.7f, 0), bomb.transform.rotation);
        bombPrefab.GetComponent<Rigidbody>().AddForce((transform.up + transform.forward) * 5, ForceMode.Impulse);
    }
}
