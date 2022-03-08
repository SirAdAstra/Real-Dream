using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardcoreGameButtonsScript : MonoBehaviour
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
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;
    [SerializeField] private GameObject target3;
    
    [Header("Buttons and Button Images")]
    [SerializeField] private Button lightButton;
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

    public void LightButton()
    {
        note1.GetComponent<HardcoreSpriteMotion>().LightNotes();
        note2.GetComponent<HardcoreSpriteMotion>().LightNotes();
        note3.GetComponent<HardcoreSpriteMotion>().LightNotes();
        target1.GetComponent<HardcoreGoalScript>().LightTarget();
        target2.GetComponent<HardcoreGoalScript>().LightTarget();
        target3.GetComponent<HardcoreGoalScript>().LightTarget();
        StartCoroutine(LightCooldown());
    }

    public void HorizontalButton()
    {
            note1.GetComponent<HardcoreSpriteMotion>().FlipHorizontal();
            note2.GetComponent<HardcoreSpriteMotion>().FlipHorizontal();
            note3.GetComponent<HardcoreSpriteMotion>().FlipHorizontal();
    }

    public void VerticalButton()
    {
            note1.GetComponent<HardcoreSpriteMotion>().FlipVertical();
            note2.GetComponent<HardcoreSpriteMotion>().FlipVertical();
            note3.GetComponent<HardcoreSpriteMotion>().FlipVertical();
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

    private IEnumerator LightCooldown()
    {
        lightButton.interactable = false;
        yield return new WaitForSeconds(5f);
        lightButton.interactable = true;
    }
}
