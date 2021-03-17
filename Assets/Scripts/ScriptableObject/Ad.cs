using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ad", menuName = "Ad", order = 51)]
public class Ad : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _views;
    [SerializeField] private float _randomizationValue = 0.1f;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public int RandomizatedViews => _views + Mathf.RoundToInt(Random.Range(-_views * _randomizationValue, _views * _randomizationValue));
    public int Views => _views;
}
