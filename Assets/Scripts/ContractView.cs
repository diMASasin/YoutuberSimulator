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
    [SerializeField] private Image _icon;
    [SerializeField] private Button _getContract;
    [SerializeField] private Time _time;

    private Contract _contract;

    public event UnityAction<Contract, ContractView> GetJobButtonClick;

    private void OnEnable()
    {
        _getContract.onClick.AddListener(OnGetJobButtonClick);
    }

    private void OnDisable()
    {
        _getContract.onClick.RemoveListener(OnGetJobButtonClick);
    }

    private void OnGetJobButtonClick()
    {
        GetJobButtonClick?.Invoke(_contract, this);
    }

    public void SetJob(Contract contract)
    {
        _contract = contract;
        RenderJob(contract);
    }

    private void RenderJob(Contract contract)
    {
        _label.text = contract.Label;
        _price.text = contract.Price.ToString() + "$";
        _workTime.text = contract.WorkTime.ToString() + "h";
        _icon.sprite = contract.Icon;
    }
}