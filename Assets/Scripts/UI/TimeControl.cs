using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [SerializeField] private float _firstSpeed = 1;
    [SerializeField] private float _secondSpeed = 2;
    [SerializeField] private float _thirdSpeed = 3;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void SetFirstSpeed()
    {
        Time.timeScale = _firstSpeed;
    }

    public void SetSecondSpeed()
    {
        Time.timeScale = _secondSpeed;
    }

    public void SetThirdSpeed()
    {
        Time.timeScale = _thirdSpeed;
    }
}
