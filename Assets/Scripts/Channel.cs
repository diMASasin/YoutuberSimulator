using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Channel : MonoBehaviour
{
    [SerializeField] private TMP_Text _subscribers;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.SubscribersChanged += OnSubscribersChanged;
    }

    private void OnDisable()
    {
        _player.SubscribersChanged -= OnSubscribersChanged;
    }

    private void OnSubscribersChanged(int subscribers)
    {
        if (_player.Subscribers < 1000)
            _subscribers.text = _player.Subscribers + " subscribers";
        else if (_player.Subscribers >= 1000 && _player.Subscribers < 10000)
            _subscribers.text = _player.Subscribers / 1000 + "." + _player.Subscribers / 10 % 100 + "K subscribers";
        else if (_player.Subscribers >= 10000 && _player.Subscribers < 1000000)
            _subscribers.text = _player.Subscribers / 1000 + "." + _player.Subscribers / 100 % 10 + "K subscribers";
        else if (_player.Subscribers >= 1000000 && _player.Subscribers < 10000000)
            _subscribers.text = _player.Subscribers / 1000000 + "." + _player.Subscribers / 10000 % 100 + "M subscribers";
        else if (_player.Subscribers >= 10000000 && _player.Subscribers < 100000000)
            _subscribers.text = _player.Subscribers / 1000000 + "." + _player.Subscribers / 100000 % 10 + "M subscribers";
        else
            _subscribers.text = _player.Subscribers / 1000000 + "M subscribers";
    }
}
