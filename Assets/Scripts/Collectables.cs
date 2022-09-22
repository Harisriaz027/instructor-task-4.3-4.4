using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("MultiPower"))
            {
                Destroy(gameObject);
                other.GetComponent<PlayerController>().multiBomb = true;
            }
            if (gameObject.CompareTag("StickyPower"))
            {
                Destroy(gameObject);
                other.GetComponent<PlayerController>().stickyBomb = true;
            }

        }
    }
    
}
