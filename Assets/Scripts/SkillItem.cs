using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _value;
    [SerializeField] private Button _improveSkillButton;
    [SerializeField] private Slider _progressBar;

    private Skill _skill;

    public event UnityAction<Skill, SkillItem> BuyButtonClick;

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
        BuyButtonClick?.Invoke(_skill, this);
    }

    public void SetSkill(Skill skill)
    {
        _skill = skill;
        RenderSkill(skill);
    }

    private void RenderSkill(Skill skill)
    {
        _icon.sprite = skill.Icon;
        _label.text = skill.Label;
        _progressBar.maxValue = skill.MaxValue;
        RenderProgressBar(skill.Value, skill.MaxValue);
    }
    
    public void RenderProgressBar(int newValue, int maxValue)
    {
        _progressBar.value = newValue;
        _value.text = newValue.ToString() + " / " + maxValue.ToString();
    }
}
