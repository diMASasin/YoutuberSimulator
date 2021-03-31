using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContractView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _workTime;
    [SerializeField] private TMP_Text _requiredSkillValue;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _getContract;

    private Contract _contract;

    public event UnityAction<Contract, ContractView> GetContractButtonClick;

    private void OnEnable()
    {
        _getContract.onClick.AddListener(OnGetContractButtonClick);
    }

    private void OnDisable()
    {
        _getContract.onClick.RemoveListener(OnGetContractButtonClick);
    }

    private void OnGetContractButtonClick()
    {
        GetContractButtonClick?.Invoke(_contract, this);
    }

    public void SetContract(Contract contract)
    {
        _contract = contract;
        RenderContract(contract);
    }

    private void RenderContract(Contract contract)
    {
        _label.text = contract.Label;
        _price.text = contract.Price.ToString() + "$";
        _workTime.text = contract.WorkTime.ToString() + "h";
        _requiredSkillValue.text = contract.RequiredSkillValue + " " + SplitWords(contract.RequiredSkill.ToString());
        _icon.sprite = contract.Icon;
    }

    private string SplitWords(string text)
    {
        string newText = text;

        for (int i = 1; i < text.Length - 1; i++)
            if (char.IsUpper(text[i]))
                newText = text.Insert(i, " ");

        return newText;
    }
}