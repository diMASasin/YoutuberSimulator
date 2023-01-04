using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTime : MonoBehaviour
{
    [SerializeField] private int _hours = 6;
    [SerializeField] private float _minutes = 0;

    public int Days { get; private set; } = 0;

    public UnityAction DayIsOver;
    public event UnityAction<GameTime> TimeChanged;

    public float Minutes
    {
        get
        {
            return _minutes;
        }
        set
        {
            _minutes = value;

            if (_minutes > 59)
            {
                _minutes -= 60;
                _hours++;
            }
        }
    }

    public int Hours
    {
        get
        {
            return _hours;
        }
        set
        {
            _hours = value;

            if (_hours > 23)
            {
                _hours -= 24;
                Days++;
                DayIsOver?.Invoke();
            }
        }
    }

    private void Update()
    {
        Minutes += Time.deltaTime;
        ChangeTime();
    }

    public void ChangeTime()
    {
        TimeChanged?.Invoke(this);
    }
}
