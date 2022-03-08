using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //public static GameController instance;

    [Header("Score text panel")]
    [SerializeField] public Text scoreText, highScoreText;
    [SerializeField] private GameObject newHighScoreText;
    public int scoreCounter, highScoreCounter;

    
    private void Start()
    {
        if (PlayerPrefs.GetInt("SceneID") == 1)
        {
            scoreCounter = PlayerPrefs.GetInt("Score");
            highScoreCounter = PlayerPrefs.GetInt("SaveScore");

            if (scoreCounter > highScoreCounter)
            {
                highScoreCounter = scoreCounter;
                PlayerPrefs.SetInt("SaveScore", highScoreCounter);
                newHighScoreText.SetActive(true);
            }

            scoreText.text = ("You slept: " + PlayerPrefs.GetInt("Score").ToString() + " seconds.");
            highScoreText.text = ("The longest sleep: " + PlayerPrefs.GetInt("SaveScore").ToString());
        }
        else if (PlayerPrefs.GetInt("SceneID") == 4)
            {
                scoreCounter = PlayerPrefs.GetInt("BWScore");
                highScoreCounter = PlayerPrefs.GetInt("BWSaveScore");

                if (scoreCounter > highScoreCounter)
                {
                    highScoreCounter = scoreCounter;
                    PlayerPrefs.SetInt("BWSaveScore", highScoreCounter);
                    newHighScoreText.SetActive(true);
                }

                scoreText.text = ("You slept: " + PlayerPrefs.GetInt("BWScore").ToString() + " seconds.");
                highScoreText.text = ("The longest sleep: " + PlayerPrefs.GetInt("BWSaveScore").ToString());
            }
        else if (PlayerPrefs.GetInt("SceneID") == 5)
            {
                scoreCounter = PlayerPrefs.GetInt("HDScore");
                highScoreCounter = PlayerPrefs.GetInt("HDSaveScore");

                if (scoreCounter > highScoreCounter)
                {
                    highScoreCounter = scoreCounter;
                    PlayerPrefs.SetInt("HDSaveScore", highScoreCounter);
                    newHighScoreText.SetActive(true);
                }

                scoreText.text = ("You slept: " + PlayerPrefs.GetInt("HDScore").ToString() + " seconds.");
                highScoreText.text = ("The longest sleep: " + PlayerPrefs.GetInt("HDSaveScore").ToString());
            }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneID"));
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
