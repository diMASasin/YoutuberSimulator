using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentsShop : MonoBehaviour
{
    [SerializeField] private List<Equipment> _equipments;
    [SerializeField] private EquipmentView _template;
    [SerializeField] private Transform _itemContainer;

    [SerializeField] protected Player _player;

    public List<Equipment> Upgrades => _equipments;

    private void Start()
    {
        for (int i = 0; i < _equipments.Count; i++)
        {
            AddEquipment(_equipments[i]);
        }
    }

    private void AddEquipment(Equipment equipment)
    {
        EquipmentView equipmentView = Instantiate(_template, _itemContainer);
        InitializeEquipment(equipmentView, equipment);
    }

    private void InitializeEquipment(EquipmentView equipmentView, Equipment equipment)
    {
        equipmentView.SetSkill(equipment);
        equipmentView.BuyButtonClick += OnBuyButtonClick;
    }

    private void OnBuyButtonClick(Equipment equipment, EquipmentView equipmentView)
    {
        TryBuyItem(equipment, equipmentView);
    }

    protected virtual void TryBuyItem(Equipment equipment, EquipmentView equipmentView) 
    {
        if (_player.CheckSolvency(equipment.Price))
        {
            equipment.Sell();
            _player.BuyEquipment(equipment.Price);
        }
    }

    public int CalculateSumOfValues()
    {
        int sumOfValues = 0;

        foreach (var upgrade in _equipments)
        {
            sumOfValues += upgrade.Value;
        }

        return sumOfValues;
    }
}
