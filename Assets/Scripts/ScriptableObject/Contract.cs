using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Contract", menuName = "Contract", order = 55)]
public class Contract : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private float _randomizationValue;
    [SerializeField] private int _workHours;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _requiredSkillValue;
    [SerializeField] private SkillsEnum _requiredSkill;

    public string Label => _label;
    public int Price => _price + Mathf.RoundToInt(Random.Range(-_price * _randomizationValue, _price * _randomizationValue));
    public int WorkTime => _workHours;
    public Sprite Icon => _icon;
    public int RequiredSkillValue => _requiredSkillValue;
    public SkillsEnum RequiredSkill => _requiredSkill;
}
    public enum SkillsEnum
    {
        ScriptWriting,
        VideoEditing,
        VideoRecording,
        Charisma
    }