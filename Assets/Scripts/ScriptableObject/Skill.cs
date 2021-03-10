using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill", order = 53)]
public class Skill : ScriptableObject
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _value = 0;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _improveSkillDuration = 1;

    public int MaxValue => _maxValue;
    public int Value => _value;
    public string Label => _label;
    public Sprite Icon => _icon;
    public int ImproveDuration => _improveSkillDuration;

    public void ImproveSkill()
    {
        _value++;
    }
}
