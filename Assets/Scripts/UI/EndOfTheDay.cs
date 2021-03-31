using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfTheDay : MonoBehaviour
{
    [SerializeField] private TMP_Text _personalExpenses;
    [SerializeField] private TMP_Text _jobIncome;
    [SerializeField] private TMP_Text _videosIncome;
    [SerializeField] private TMP_Text _contractsIncome;
    [SerializeField] private TMP_Text _totalText;
    [SerializeField] private Player _player;
    [SerializeField] private Button _continueButton;

    private int _total;
    private Color _greenColor = new Color(226 / 255.0f, 167 / 255.0f, 29 / 255.0f); 
    private Color _redColor = new Color(224 / 255.0f, 50 / 255.0f, 50 / 255.0f);
    private Color _grayColor = new Color(96 / 255.0f, 96 / 255.0f, 96 / 255.0f);

    private void OnEnable()
    {
        _totalText.text = "";

        _personalExpenses.text = "-" + _player.PersonalExpenses.ToString() + "$";
        _jobIncome.text = "+" + _player.JobIncome.ToString() + "$";
        _videosIncome.text = "+" + _player.VideosIncome.ToString() + "$";
        _contractsIncome.text = "+" + _player.ContractsIncome.ToString() + "$";

        _total = -_player.PersonalExpenses + _player.JobIncome + _player.VideosIncome + _player.ContractsIncome;

        if (_total > 0)
        {
            _totalText.color = _greenColor;
            _totalText.text = "+";
        }
        else if (_total < 0)
        {
            _totalText.color = _redColor;
        }
        else
        { 
            _totalText.color = _grayColor;
        }
                
        _totalText.text += _total.ToString() + "$";
        _player.Pay(_player.PersonalExpenses);

        _continueButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(CloseWindow);
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
