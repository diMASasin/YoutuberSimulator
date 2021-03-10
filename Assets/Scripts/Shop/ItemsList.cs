using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipments
{
    Ad,
    PC,
    Camera,
    Microphone,
    Environment
}

public class ItemsList : MonoBehaviour
{
    [SerializeField] private List<Upgrade> _upgrades;
    [SerializeField] private Item _template;
    [SerializeField] private Transform _itemContainer;
    [SerializeField] private Equipments _equipments;

    [SerializeField] protected Player _player;

    public List<Upgrade> Upgrades => _upgrades;

    private void Start()
    {
        for (int i = 0; i < _upgrades.Count; i++)
        {
            AddItem(_upgrades[i]);
        }
    }

    private void AddItem(Upgrade upgrade)
    {
        Item item = Instantiate(_template, _itemContainer);
        InitializeItem(item, upgrade);
    }

    private void InitializeItem(Item item, Upgrade upgrade)
    {
        item.SetSkill(upgrade);
        item.BuyButtonClick += OnBuyButtonClick;
    }

    private void OnBuyButtonClick(Upgrade upgrade, Item item)
    {
        TryBuyItem(upgrade, item);
    }

    protected virtual void TryBuyItem(Upgrade upgrade, Item item) 
    {
        if (_player.CheckSolvency(upgrade.Price))
        {
            upgrade.Sell();
            _player.BuyEquipment(upgrade.Price);
        }
    }

    public int CalculateSumOfValues()
    {
        int sumOfValues = 0;

        foreach (var upgrade in _upgrades)
        {
            sumOfValues += upgrade.Value;
        }

        return sumOfValues;
    }
}
