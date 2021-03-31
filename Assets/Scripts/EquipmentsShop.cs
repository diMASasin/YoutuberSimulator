using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentsShop : MonoBehaviour
{
    [SerializeField] private List<Equipment> _equipments;
    [SerializeField] private EquipmentView _template;
    [SerializeField] private Transform _itemContainer;
    [SerializeField] private Player _player;

    private List<EquipmentView> _equipmentViews = new List<EquipmentView>();

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
        _equipmentViews.Add(equipmentView);
        InitializeEquipment(equipmentView, equipment);
    }

    private void InitializeEquipment(EquipmentView equipmentView, Equipment equipment)
    {
        equipmentView.SetSkill(equipment);
        equipmentView.BuyButtonClick += OnBuyButtonClick;
    }

    private void OnBuyButtonClick(Equipment equipment, EquipmentView equipmentView)
    {
        TryBuyEquipment(equipment, equipmentView);
    }

    protected virtual void TryBuyEquipment(Equipment equipment, EquipmentView equipmentView) 
    {
        if (_player.CheckSolvency(equipment.Price))
        {
            equipmentView.ShowCheckMark();
            equipmentView.DisableButton();
            equipment.Sell();
            _player.Pay(equipment.Price);
        }
    }

    public int CalculateSumOfValues()
    {
        int sumOfValues = 0;

        foreach (var equipment in _equipments)
        {
            if(equipment.WasBought)
                sumOfValues += equipment.Value;
        }

        return sumOfValues;
    }
}
