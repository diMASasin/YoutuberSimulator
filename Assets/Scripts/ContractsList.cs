using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsList : MonoBehaviour
{
    [SerializeField] private List<Contract> _contracts;
    [SerializeField] private ContractItem _template;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;

    private void Start()
    {
        foreach (var job in _contracts)
        {
            AddItem(job);
        }
    }

    private void AddItem(Contract contract)
    {
        ContractItem contractItem = Instantiate(_template, _container);
        InitializeItem(contractItem, contract);
    }

    private void InitializeItem(ContractItem contractItem, Contract contract)
    {
        contractItem.SetJob(contract);
        contractItem.GetJobButtonClick += OnGetJobButtonClick;

    }

    private void OnGetJobButtonClick(Contract contract, ContractItem contractItem)
    {
        _player.GetContract(contract);
    }
}