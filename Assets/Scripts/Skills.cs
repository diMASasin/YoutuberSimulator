using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills;
    [SerializeField] private Player _player;
    [SerializeField] private SkillItem _template;
    [SerializeField] private Transform _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _skills.Count; i++)
        {
            AddItem(_skills[i]);
        }
    }

    private void AddItem(Skill skill)
    {
        SkillItem skillItem = Instantiate(_template, _itemContainer);
        InitializeItem(skillItem, skill);
    }

    private void InitializeItem(SkillItem skillItem, Skill skill)
    {
        skillItem.SetSkill(skill);
        skillItem.BuyButtonClick += OnBuyButtonClick;

    }

    private void OnBuyButtonClick(Skill skill, SkillItem skillItem)
    {
        TryImproveSkill(skill, skillItem);
    }

    private void TryImproveSkill(Skill skill, SkillItem skillItem)
    {
        if (_player.IsEnoughTime(skill.ImproveDuration))
        {
            skill.ImproveSkill();
            skillItem.RenderProgressBar(skill.Value, skill.MaxValue);
            _player.SpendTime(skill.ImproveDuration);
        }
    }
}
