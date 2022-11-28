using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField] Text scoreText;


    void Start()
    {
          
    }

    void Update()
    {
        Score();
    }


    void Score()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
