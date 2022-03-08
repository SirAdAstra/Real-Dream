using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart = 60f;
    public Text timerText;

    
    private void Start()
    {
        timerText.text = timeStart.ToString();
    }

    
    private void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        if(timeStart < 0)
        {
            PlayerPrefs.SetInt("SceneID", SceneManager.GetActiveScene().buildIndex);

            if(PlayerPrefs.GetInt("SceneID") == 1)
                PlayerPrefs.SetInt("Score", GameController._score);
            else if (PlayerPrefs.GetInt("SceneID") == 4)
                PlayerPrefs.SetInt("BWScore", GameController._score);
            else if((PlayerPrefs.GetInt("SceneID") == 5))
                PlayerPrefs.SetInt("HDScore", GameController._score);
            
            SceneManager.LoadScene("score");
        }
    }

    public void AddTime()
    {
        timeStart += 2.5f;
    }
}
