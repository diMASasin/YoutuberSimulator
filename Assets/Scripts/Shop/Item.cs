using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _improveSkillButton;

    private Upgrade _upgrade;

    public event UnityAction<Upgrade, Item> BuyButtonClick;

    private void OnEnable()
    {
        _improveSkillButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        _improveSkillButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClick?.Invoke(_upgrade, this);
    }

    public void SetSkill(Upgrade upgrade)
    {
        _upgrade = upgrade;
        RenderSkill(upgrade);
    }

    private void RenderSkill(Upgrade upgrade)
    {
        _icon.sprite = upgrade.Icon;
        _label.text = upgrade.Label;
        _description.text = "+" + upgrade.Value.ToString() + " " + upgrade.Description;
        _price.text = upgrade.Price.ToString();
    }
}
