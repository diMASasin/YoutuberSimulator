using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _subscribers;
    [SerializeField] private Time _time;
    [SerializeField] private int _sleepTime = 22;
    [SerializeField] private int _sleepDuration = 8;
    [SerializeField] private List<EquipmentsShop> _itemsList;
    [SerializeField] private Skills _skills;

    public int Subscribers => _subscribers;
    public List<EquipmentsShop> ItemsList => _itemsList;
    public Skills Skills => _skills;

    public int ViewsBonus { get; private set; }

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> SubscribersChanged;
    public event UnityAction<Time> TimeChanged;

    private Job _job;

    private void Start()
    {
        SubscribersChanged?.Invoke(_subscribers);
        MoneyChanged?.Invoke(_money);
        TimeChanged?.Invoke(_time);
    }

    public bool IsEnoughTime(int duration)
    {
        return _time.Hours + duration <= _sleepTime;
    }

    public void MakeVideo(int subscriptions, int income, int makeVideoDuration)
    {
        _money += income;
        MoneyChanged?.Invoke(_money);

        _subscribers += subscriptions;
        SubscribersChanged?.Invoke(_subscribers);

        _time.Hours += makeVideoDuration;
        TimeChanged?.Invoke(_time);

    }

    public void BuyEquipment(int price)
    {
        _money -= price;
        MoneyChanged?.Invoke(_money);
    }

    public void BuyAd(Ad ad)
    {
        ViewsBonus += ad.RandomizatedViews;
        _money -= ad.Price;
        MoneyChanged?.Invoke(_money);
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
