using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animation))]
public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    private Animation _anim;

    private void Start()
    {
        _anim = GetComponent<Animation>();
    }

    public void NewGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void PlayModesButton()
    {
        _anim.Play("MenuSlideLeft");
    }

    public void BackPlayModesButton()
    {
        _anim.Play("PlayModesBack");
    }

    public void SettingsButton()
    {
        _anim.Play("MenuSlideRight");
    }

    public void BackSettingsButton()
    {
        _anim.Play("SettingsBack");
    }

    public void BWMode(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void NewGameDzen(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void HardcoreButton(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Tutorial(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    } 

    public void Settings(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }  

    public void Exit()
    {
         Application.Quit();
    }  
}
