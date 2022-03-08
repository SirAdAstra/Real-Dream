using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWGameButtonsScript : MonoBehaviour
{
    private enum MusicStatus
    {
        Forward,
        Backward
    }
    private MusicStatus _musicStatus;
    public static int _publMusicStatus;

    [Header("Notes And Targets")]
    [SerializeField] private GameObject note1;
    [SerializeField] private GameObject note2;
    [SerializeField] private GameObject note3;
    
    [Header("Button Images")]
    [SerializeField] private GameObject horNightImg;
    [SerializeField] private GameObject verNightImg;
    [SerializeField] private GameObject musicForvardImg;
    [SerializeField] private GameObject musicBackwardImg;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSourceForward;
    [SerializeField] private AudioSource audioSourceBackward;


    private void Start()
    {
        _musicStatus = MusicStatus.Forward;
        _publMusicStatus = (int)_musicStatus;
    }

    public void HorizontalButton()
    {
            note1.GetComponent<BWSpriteMotion>().FlipHorizontal();
            note2.GetComponent<BWSpriteMotion>().FlipHorizontal();
            note3.GetComponent<BWSpriteMotion>().FlipHorizontal();
    }

    public void VerticalButton()
    {
            note1.GetComponent<BWSpriteMotion>().FlipVertical();
            note2.GetComponent<BWSpriteMotion>().FlipVertical();
            note3.GetComponent<BWSpriteMotion>().FlipVertical();
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
