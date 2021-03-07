using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Job", menuName = "Job", order = 52)]
public class Job : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _salary;
    [SerializeField] private Time _workTime;
    [SerializeField] private Sprite _icon;

    public string Label => _label;
    public int Salary => _salary;
    public Time WorkTime => _workTime;
    public Sprite Icon => _icon;
}
