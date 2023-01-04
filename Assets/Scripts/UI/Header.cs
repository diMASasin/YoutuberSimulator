using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Header : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _subscribersText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private Player _player;
    [SerializeField] private GameTime _gameTime;
    [SerializeField] private GameObject _messageTemplate;
    [SerializeField] private Transform _messageContainer;

    private void OnEnable()
    {
        _gameTime.TimeChanged += OnTimeChanged;
        _player.MoneyChanged += OnMoneyChanged;
        _player.SubscribersChanged += OnSubscribersChanged;
        _player.NotEnoughTime += ShowMessage;
    }

    private void OnDisable()
    {
        _gameTime.TimeChanged -= OnTimeChanged;
        _player.MoneyChanged -= OnMoneyChanged;
        _player.SubscribersChanged -= OnSubscribersChanged;
        _player.NotEnoughTime -= ShowMessage;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }

    private void OnSubscribersChanged(int subscriptions)
    {
        _subscribersText.text = subscriptions.ToString();
    }

    private void OnTimeChanged(GameTime time)
    {
        _timeText.text = "Day " + time.Days.ToString() + "  " + time.Hours.ToString() + ":" + string.Format("{0:d2}", (int)time.Minutes);
    }

    private void ShowMessage(string message)
    {
        Instantiate(_messageTemplate, _messageContainer);
    }
}
