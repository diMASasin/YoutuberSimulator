using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _buyButton;

    private Equipment _equipment;

    public event UnityAction<Equipment, EquipmentView> BuyButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClick?.Invoke(_equipment, this);
        _buyButton.interactable = false;
    }

    public void SetSkill(Equipment equipment)
    {
        _equipment = equipment;
        RenderSkill(equipment);
    }

    private void RenderSkill(Equipment equipment)
    {
        _icon.sprite = equipment.Icon;
        _label.text = equipment.Label;
        _description.text = "+" + equipment.Value.ToString() + " " + equipment.Description;
        _price.text = equipment.Price.ToString();
    }
}
