using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGameButtonsScript : MonoBehaviour
{
    private enum Daytime
    {
        Day,
        Night
    }
    private Daytime _daytime;
    public static int _publDaytime;

    private enum MusicStatus
    {
        Forward,
        Backward
    }
    private MusicStatus _musicStatus;
    public static int _publMusicStatus;


    [Header("Backgrounds")]
    [SerializeField] private GameObject dayBckg;
    [SerializeField] private GameObject nightBckg;

    [Header("Notes")]
    [SerializeField] private GameObject note1;
    
    [Header("Button Images")]
    [SerializeField] private GameObject dayImg;
    [SerializeField] private GameObject nightImg;
    [SerializeField] private GameObject horDayImg;
    [SerializeField] private GameObject horNightImg;
    [SerializeField] private GameObject verDayImg;
    [SerializeField] private GameObject verNightImg;
    [SerializeField] private GameObject pauseDayImg;
    [SerializeField] private GameObject pauseightImg;
    [SerializeField] private GameObject musicForvardImg;
    [SerializeField] private GameObject musicBackwardImg;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSourceForward;
    [SerializeField] private AudioSource audioSourceBackward;


    private void Start()
    {
        _daytime = Daytime.Day;
        _musicStatus = MusicStatus.Forward;
        _publDaytime = (int)_daytime;
        _publMusicStatus = (int)_musicStatus;
    }

    public void Day_Night_Switch()
    {
        if (dayBckg.activeInHierarchy)
        {
            nightBckg.SetActive(true);
            dayBckg.SetActive(false);
            nightImg.SetActive(true);
            dayImg.SetActive(false);
            horNightImg.SetActive(true);
            horDayImg.SetActive(false);
            verNightImg.SetActive(true);
            verDayImg.SetActive(false);
            pauseightImg.SetActive(true);
            pauseDayImg.SetActive(false);
            musicBackwardImg.SetActive(true);
            musicForvardImg.SetActive(false);
            _daytime = Daytime.Night;
            _publDaytime = (int)_daytime;
        }
        else if (nightBckg.activeInHierarchy)
        {
            dayBckg.SetActive(true);
            nightBckg.SetActive(false);
            dayImg.SetActive(true);
            nightImg.SetActive(false);
            horDayImg.SetActive(true);
            horNightImg.SetActive(false);
            verDayImg.SetActive(true);
            verNightImg.SetActive(false);
            pauseDayImg.SetActive(true);
            pauseightImg.SetActive(false);
            musicForvardImg.SetActive(true);
            musicBackwardImg.SetActive(false);
            _daytime = Daytime.Day;
            _publDaytime = (int)_daytime;
        }
        note1.GetComponent<TutorialSpriteMotion>().ChangeColor();
    }

    public void HorizontalButton()
    {
            note1.GetComponent<TutorialSpriteMotion>().FlipHorizontal();
    }

    public void VerticalButton()
    {
            note1.GetComponent<TutorialSpriteMotion>().FlipVertical();
    }

    public void MusicReverseButton()
    {
        //make music reverse
        if (audioSourceBackward.mute)
        {
            audioSourceBackward.mute = false;
            audioSourceForward.mute = true;
            _musicStatus = MusicStatus.Backward;
            _publMusicStatus = (int)_musicStatus;
        }
        else if (audioSourceForward.mute)
        {
            audioSourceForward.mute = false;
            audioSourceBackward.mute = true;
            _musicStatus = MusicStatus.Forward;
            _publMusicStatus = (int)_musicStatus;
        }
    }
}
