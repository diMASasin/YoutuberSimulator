using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _subscribers;
    [SerializeField] private int _sleepTime = 22;
    [SerializeField] private int _sleepDuration = 8;
    [SerializeField] private int _personalExpensesValue = 75;
    [SerializeField] private Time _time;
    [SerializeField] private List<EquipmentsShop> _equipmentShops;
    [SerializeField] private Skills _skills;

    public int Subscribers => _subscribers;
    public int JobIncome => _job == null ? 0 : _job.Salary;
    public int PersonalExpenses => _personalExpensesValue;
    public List<EquipmentsShop> EquipmetShops => _equipmentShops;
    public Skills Skills => _skills;


    public int ViewsBonus { get; private set; }
    public int VideosIncome { get; private set; } = 0;
    public int ContractsIncome { get; private set; } = 0;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> SubscribersChanged;
    public event UnityAction<Time> TimeChanged;
    public event UnityAction<string> NotEnoughTime;

    private Job _job;

    private void Start()
    {
        SubscribersChanged?.Invoke(_subscribers);
        MoneyChanged?.Invoke(_money);
        TimeChanged?.Invoke(_time);
    }

    public bool IsEnoughTime(int duration)
    {
        bool isEnoughTime = _time.Hours + duration <= _sleepTime;

        if (!isEnoughTime)
            NotEnoughTime?.Invoke($"Not enough time, at {_sleepTime} you need to go to bed!");

        return isEnoughTime;
    }

    public void MakeVideo(int subscriptions, int income, int makeVideoDuration)
    {
        _money += income;
        MoneyChanged?.Invoke(_money);
        VideosIncome += income;

        _subscribers += subscriptions;
        SubscribersChanged?.Invoke(_subscribers);

        _time.Hours += makeVideoDuration;
        TimeChanged?.Invoke(_time);

    }

    public void Pay(int price)
    {
        _money -= price;
        MoneyChanged?.Invoke(_money);
    }

    public void BuyAd(Ad ad)
    {
        ViewsBonus += ad.RandomizatedViews;
        Pay(ad.Price);
    }

    public void ResetBonus()
    {
        ViewsBonus = 0;
    }

    public bool CheckSolvency(int price)
    {
        return _money >= price;
    }

    public void Sleep()
    {
        _time.Hours += _sleepTime - _time.Hours + _sleepDuration;
        TimeChanged?.Invoke(_time);

        ContractsIncome = 0;
        VideosIncome = 0;

        Work();
    }

    public void GetJob(Job job)
    {
        _job = job;
    }

    public void GetContract(Contract contract)
    {
        _time.Hours += contract.WorkTime;
        TimeChanged?.Invoke(_time);

        _money += contract.Price;
        MoneyChanged?.Invoke(_money);
        ContractsIncome += contract.Price;
    }

    private void Work()
    {
        if (_job == null)
            return;

        _time.Hours += _job.WorkTime;
        TimeChanged?.Invoke(_time);

        _money += _job.Salary;
        MoneyChanged?.Invoke(_money);
    }

    public void ImproveSkill(int time)
    {
        _time.Hours += time;
        TimeChanged?.Invoke(_time);
    }
}
