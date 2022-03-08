using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightChange : MonoBehaviour
{
    [Header("Backgounds")]
    [SerializeField] private GameObject _dayBackground;
    [SerializeField] private GameObject _nightBackground;

    private void Start()
    {
        var currentDate = System.DateTime.Now;
        
        if (currentDate.Hour >= 6 && currentDate.Hour <= 18)
        {
            _dayBackground.SetActive(true);
            _nightBackground.SetActive(false);
        }
        else
        {
            _nightBackground.SetActive(true);
            _dayBackground.SetActive(false);
        }
    }
}
