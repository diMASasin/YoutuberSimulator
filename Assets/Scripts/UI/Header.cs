using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Header : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _subscribers;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private GameObject _messageTemplate;
    [SerializeField] private Transform _messageContainer;

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
        _player.SubscribersChanged += OnSubscribersChanged;
        _player.TimeChanged += OnTimeChanged;
        _player.NotEnoughTime += ShowMessage;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
        _player.SubscribersChanged -= OnSubscribersChanged;
        _player.TimeChanged -= OnTimeChanged;
        _player.NotEnoughTime -= ShowMessage;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }

    private void OnSubscribersChanged(int subscriptions)
    {
        _subscribers.text = subscriptions.ToString();
    }

    private void OnTimeChanged(Time time)
    {
        _time.text = "Day " + time.Days.ToString() + "  " + time.Hours.ToString() + ":" + time.Minutes.ToString() + "0";
    }

    private void ShowMessage(string message)
    {
        Instantiate(_messageTemplate, _messageContainer);
    }
}
