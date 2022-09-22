using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveNumber : MonoBehaviour
{
    public TMP_Text text;
    int count;
    void Start()
    {
        
    }

    void Update()
    {
        count = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().waveNumber;
        text.text = count.ToString("Wave "+count+"/5");
    }
}
