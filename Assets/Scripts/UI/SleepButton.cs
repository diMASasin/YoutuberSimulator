using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepButton : MonoBehaviour
{
    [SerializeField] private Button _sleepButton;
    [SerializeField] private GameObject _endOfTheDayWindow;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _sleepButton.onClick.AddListener(OpenEndOfTheDay);
        _sleepButton.onClick.AddListener(OnSleepButtonClick);
    }

    private void OnDisable()
    {
        _sleepButton.onClick.RemoveListener(OpenEndOfTheDay);
        _sleepButton.onClick.RemoveListener(OnSleepButtonClick);
    }

    private void OnSleepButtonClick()
    {
        _player.Sleep();
    }

    private void OpenEndOfTheDay()
    {
        _endOfTheDayWindow.SetActive(true);
    }
}
