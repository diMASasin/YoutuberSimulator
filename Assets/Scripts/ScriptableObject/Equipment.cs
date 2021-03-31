using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment", fileName = "New Equipment", order = 54)]
public class Equipment : ScriptableObject
{
    [SerializeField] private string _label = "test";
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price = 100;
    [SerializeField] private int _value = 1;

    public bool WasBought { get; private set; }

    public string Label => _label;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int Value => _value;

    public void Sell()
    {
        WasBought = true;
    }
}
