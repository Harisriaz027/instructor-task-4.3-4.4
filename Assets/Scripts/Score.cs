using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TMP_Text text;
    public int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        text.text = score.ToString("Enemies killed "+score);
    }
}
