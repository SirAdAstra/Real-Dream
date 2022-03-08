using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject dayPauseMenu;
    [SerializeField] private GameObject nightPauseMenu;

    public void Pause()
    {
        Time.timeScale = 0f;

        var currentDate = System.DateTime.Now;

        if (currentDate.Hour >= 6 && currentDate.Hour <= 18)
        {
            dayPauseMenu.SetActive(true);
        }
        else
        {
            nightPauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        dayPauseMenu.SetActive(false);
        nightPauseMenu.SetActive(false);
        Time.timeScale =1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
    public void restart(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
