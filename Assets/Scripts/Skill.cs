using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private int _improveSkillDuration = 1;
    [SerializeField] private int _value;
    [SerializeField] private int _maxValue = 100;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Button _improveSkillButton;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Player _player;

    public int Value => _value;

    private void OnEnable()
    {
        _improveSkillButton.onClick.AddListener(OnImproveSkillButtonClick);
    }

    private void OnDisable()
    {
        _improveSkillButton.onClick.RemoveListener(OnImproveSkillButtonClick);
    }

    private void Start()
    {
        _progressBar.maxValue = _maxValue;
        _progressBar.wholeNumbers = true;
    }

    private void OnImproveSkillButtonClick()
    {
        if (!_player.IsEnoughTime(_improveSkillDuration))
            return;

        _value++;
        _progressBar.value = _value;
        _valueText.text = _progressBar.value.ToString() + " / " + _progressBar.maxValue.ToString();
        _player.ImproveSkill(_improveSkillDuration);
    }
}
