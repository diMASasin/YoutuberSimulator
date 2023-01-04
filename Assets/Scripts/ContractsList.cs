using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsList : MonoBehaviour
{
    [SerializeField] private List<Contract> _contracts;
    [SerializeField] private ContractView _template;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;
    [SerializeField] private GameTime _time;

    private List<ContractView> _contractViews = new List<ContractView>();

    private void Start()
    {
        FormContractsForDay();
    }

    private void OnEnable()
    {
        _time.DayIsOver += FormContractsForDay;
    }

    private void OnDisable()
    {
        _time.DayIsOver -= FormContractsForDay;
    }

    private void FormContractsForDay()
    {
        int numOfContracts = Random.Range(7, 15);
        int contractIndex;

         foreach (var contractView in _contractViews)
            Destroy(contractView.gameObject);

         _contractViews.Clear();

        for (int i = 0; i < numOfContracts; i++)
        {
            contractIndex = Random.Range(0, _contracts.Count);
            AddContract(_contracts[contractIndex]);
        }
    }

    private void AddContract(Contract contract)
    {
        ContractView contractItem = Instantiate(_template, _container);
        _contractViews.Add(contractItem);
        InitializeContract(contractItem, contract);
    }

    private void InitializeContract(ContractView contractItem, Contract contract)
    {
        contractItem.SetContract(contract);
        contractItem.GetContractButtonClick += OnGetJobButtonClick;

    }

    private void OnGetJobButtonClick(Contract contract, ContractView contractView)
    {
        SetRequiredSkill(contract, out Skill requiredSkill);

        if (requiredSkill.Value < contract.RequiredSkillValue || !_player.IsEnoughTime(contract.WorkTime))
            return;

        _player.GetContract(contract);
        _contractViews.Remove(contractView);
        Destroy(contractView.gameObject);
        contractView.GetContractButtonClick -= OnGetJobButtonClick;
    }

    private void SetRequiredSkill(Contract contract, out Skill skill)
    {
        skill = null;

        if (contract.RequiredSkill == SkillsEnum.Charisma)
            skill = _player.Skills.Charisma;
        else if (contract.RequiredSkill == SkillsEnum.ScriptWriting)
            skill = _player.Skills.ScriptWriting;
        else if (contract.RequiredSkill == SkillsEnum.VideoEditing)
            skill = _player.Skills.VideoEditing;
        else if (contract.RequiredSkill == SkillsEnum.VideoRecording)
            skill = _player.Skills.VideoRecording;
    }
}