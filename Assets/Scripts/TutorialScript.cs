using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject musicButton;
    [SerializeField] private GameObject verticalButton;
    [SerializeField] private GameObject horizontalButton;
    [SerializeField] private GameObject dayNightButton;

    [Header("Tutorial")]
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject goalImg;
    [SerializeField] private GameObject musicImg;
    [SerializeField] private GameObject horVerImg;
    [SerializeField] private GameObject dayNightImg;
    private int tutorialCounter = 0;

    private void Start()
    {
        goalImg.SetActive(true);
        tutorialPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueButton()
    {
        tutorialPanel.SetActive(false);
        goalImg.SetActive(false);
        musicImg.SetActive(false);
        horVerImg.SetActive(false);
        dayNightImg.SetActive(false);
        tutorialCounter += 1;
        Time.timeScale = 1;

        if (tutorialCounter < 5)
            StartCoroutine(TutorialTimer());
    }

    private void ShowNewHelp()
    {
        if (tutorialCounter == 1)
        {
            musicImg.SetActive(true);
            musicButton.SetActive(true);
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (tutorialCounter == 2)
        {
            horVerImg.SetActive(true);
            horizontalButton.SetActive(true);
            verticalButton.SetActive(true);
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (tutorialCounter == 3)
        {
            dayNightImg.SetActive(true);
            dayNightButton.SetActive(true);
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (tutorialCounter == 4)
        {
            StartCoroutine(TutorialEnd());
        }
    }

    private IEnumerator TutorialTimer()
    {
        yield return new WaitForSeconds(5f);
        ShowNewHelp();
    }

    private IEnumerator TutorialEnd()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(0);
    }
}
