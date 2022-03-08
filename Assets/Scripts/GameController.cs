using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text score;
    public int scoreCounter;
    public static int _score;
    private void Start()
    {
        scoreCounter = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        score.text = "Score: " + scoreCounter;
        _score = scoreCounter;
        //далше будет тригер и score+=50;
    }

    public void AddScore()
    {
        scoreCounter += 50;
    }
}
