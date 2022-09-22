using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject enemy;
    public ParticleSystem bombParticle;
    public AudioClip booom;
    public int score;
    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(BombExplodeRoutine());
    }

    IEnumerator BombExplodeRoutine()
    {
        yield return new WaitForSeconds(5);
        AudioSource.PlayClipAtPoint(booom, gameObject.transform.position);
        Instantiate(bombParticle, transform.position, bombParticle.transform.rotation);
        
        Destroy(gameObject);
        enemy = GameObject.Find("BombRadius").GetComponent<ExplosionRadius>().enemy;
        if (enemy != null)
        {
            GameObject.Find("Score").GetComponent<Score>().score++;
        }
        Destroy(enemy);
        
    }

}
