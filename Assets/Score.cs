using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI _scoreMesh;
    public static int score;
    public static int life;
    void Start()
    {
        _scoreMesh.text = "Score: 0, Life: ";
    }

    // Update is called once per frame
    void Update()
    {
        _scoreMesh.text = "Score: "+score+", Life: "+life;

    }
}
