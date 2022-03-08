using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievementmanager : MonoBehaviour
{
    [Header("Achievement")]
    [SerializeField] private GameObject _lockBackground, _lockBackground1, _lockBackground2, _lockBackground3, _lockBackground4, _lockBackground5, _lockBackground6; // _lockBackground7, _lockBackground8;
    [SerializeField] private GameObject _unlockBackground, _unlockBackground1, _unlockBackground2, _unlockBackground3, _unlockBackground4, _unlockBackground5, _unlockBackground6; // _unlockBackground7, _unlockBackground8;
        // Start is called before the first frame update
        
        void Start()
        {
            if (PlayerPrefs.GetInt("SaveScore") >= 300)
            {
                _unlockBackground.SetActive(true);
                _lockBackground.SetActive(false);
            }
            else
            {
                _lockBackground.SetActive(true);
                _unlockBackground.SetActive(false);  // 1
            }
            if (PlayerPrefs.GetInt("SaveScore") >= 700)
            {
                _unlockBackground1.SetActive(true);
                _lockBackground1.SetActive(false);
            }
            else
            {
                _lockBackground1.SetActive(true);
                _unlockBackground1.SetActive(false);     // 2
            }
            if (PlayerPrefs.GetInt("SaveScore") >= 1500)
            {
                _unlockBackground2.SetActive(true);
                _lockBackground2.SetActive(false);
            }
            else
            {
                _lockBackground2.SetActive(true);
                _unlockBackground2.SetActive(false); // 3
            }
            if (PlayerPrefs.GetInt("SaveScore") >= 3000)
            {
                _unlockBackground3.SetActive(true);
                _lockBackground3.SetActive(false);
            }
            else
            {
                _lockBackground3.SetActive(true);
                _unlockBackground3.SetActive(false); // 4
            }
            if (PlayerPrefs.GetInt("SaveScore") >= 10000)
            {
                _unlockBackground4.SetActive(true);
                _lockBackground4.SetActive(false);
            }
            else
            {
                _lockBackground4.SetActive(true);
                _unlockBackground4.SetActive(false); // 5
            }
            if (PlayerPrefs.GetInt("HDSaveScore") >= 700)
            {
                _unlockBackground5.SetActive(true);
                _lockBackground5.SetActive(false);
            }
            else
            {
                _lockBackground5.SetActive(true);
                _unlockBackground5.SetActive(false); // 6
            }
            if (PlayerPrefs.GetInt("BWSaveScore") >= 700)
            {
                _unlockBackground6.SetActive(true);
                _lockBackground6.SetActive(false);
            }
            else
            {
                _lockBackground6.SetActive(true);
                _unlockBackground6.SetActive(false); //7
            }
        }
}
