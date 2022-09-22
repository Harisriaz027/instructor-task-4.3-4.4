using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem bombParticle;
    public AudioClip booom,fire;
    void Start()
    {
        
    }

    
    void Update()
    {
        StartCoroutine(BombExplodeRoutine());
        
    }
    IEnumerator BombExplodeRoutine()
    {
        yield return new WaitForSeconds(7);
        AudioSource.PlayClipAtPoint(booom, transform.position);
        Instantiate(bombParticle, transform.position, bombParticle.transform.rotation);
        Destroy(gameObject);
        player = GameObject.Find("EnemyBombRadius").GetComponent<ExplosionRadius>().player;
        Destroy(player);
        if (player != null)
        {
           
            Time.timeScale = 0;
        }
    }
    
    }
    
