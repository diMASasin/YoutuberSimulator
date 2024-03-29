﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Job", menuName = "Job", order = 52)]
public class Job : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _salary;
    [SerializeField] private int _workHours;
    [SerializeField] private Sprite _icon;

    public string Label => _label;
    public int Salary => _salary;
    public int WorkTime => _workHours;
    public Sprite Icon => _icon;
}
