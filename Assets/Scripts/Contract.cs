using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Contract", menuName = "Contract", order = 55)]
public class Contract : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private int _workHours;
    [SerializeField] private Sprite _icon;

    public string Label => _label;
    public int Price => _price;
    public int WorkTime => _workHours;
    public Sprite Icon => _icon;
}