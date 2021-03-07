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
    //[SerializeField] private int _sleepDuration = 8;


    private Job _job;

    public int ViewsBonus { get; private set; }
    public int Subscribers => _subscribers;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> SubscribersChanged;
    public event UnityAction<Time> TimeChanged;

    private void Start()
    {
        SubscribersChanged?.Invoke(_subscribers);
        MoneyChanged?.Invoke(_money);
        TimeChanged?.Invoke(_time);
    }

    public bool IsEnoughTime(int duration)
    {
        return _time.Hours + duration > _sleepTime ? false : true;
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
    public void BuyAd(Ad ad)
    {
        _money -= ad.Price;
        ViewsBonus += ad.Views;
        MoneyChanged?.Invoke(_money);
    }

    public bool CheckSolvency(int price)
    {
        return _money >= price;
    }

    public void ResetBonus()
    {
        ViewsBonus = 0;
    }

    public void Sleep()
    {
        _time.Hours = 6;
        _time.Days++;
        TimeChanged?.Invoke(_time);

        Work();
    }

    public void GetJob(Job job)
    {
        _job = job;
    }

    private void Work()
    {
        if (_job == null)
            return;

        _time.Hours += _job.WorkTime.Hours;
        _time.Minutes += _job.WorkTime.Minutes;
        TimeChanged?.Invoke(_time);

        _money += _job.Salary;
        MoneyChanged?.Invoke(_money);
    }

    public void SpendTime(int time)
    {
        _time.Hours += time;
        TimeChanged?.Invoke(_time);
    }
}
