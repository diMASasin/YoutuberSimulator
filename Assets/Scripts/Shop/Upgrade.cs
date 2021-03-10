using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade", fileName = "New Upgrade", order = 54)]
public class Upgrade : ScriptableObject
{
    [SerializeField] private string _label = "test";
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price = 100;
    [SerializeField] private int _value = 1;

    private bool _wasBought;

    public string Label => _label;
    public string Description => _description;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int Value => _value;

    public void Sell()
    {
        _wasBought = true;
    }
}
