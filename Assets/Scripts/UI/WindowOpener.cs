using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> _windowsToOpen;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        if(_openButton != null)
            _openButton.onClick.AddListener(ShowWindow);
        if (_closeButton != null)
            _closeButton.onClick.AddListener(HideWindow);
    }

    private void OnDisable()
    {
        if (_openButton != null)
            _openButton.onClick.RemoveListener(ShowWindow);
        if (_closeButton != null)
            _closeButton.onClick.RemoveListener(HideWindow);
    }

    public void ShowWindow()
    {
        foreach (var window in _windowsToOpen)
        {
            window.alpha = 1;
            window.blocksRaycasts = true;
            window.interactable = true;
        }
    }

    public void HideWindow()
    {
        foreach (var window in _windowsToOpen)
        {
            window.alpha = 0;
            window.blocksRaycasts = false;
            window.interactable = false;
        }
    }
}
