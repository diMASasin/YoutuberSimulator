﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour
{
    public int Days = 0;

    [SerializeField] private int _hours = 6;
    [SerializeField] private int _minutes = 00;

    public int Minutes
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
            }
        }
    }
}