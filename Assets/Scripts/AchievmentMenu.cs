using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievmentMenu : MonoBehaviour
{
    [SerializeField] private GameObject AchievmentScene;

    public void Acievment()
    {
        AchievmentScene.SetActive(true);
        Time.timeScale = 0f;       
    }
    public void Resume()
    {
        AchievmentScene.SetActive(false);
        Time.timeScale = 1f;
    }
}
