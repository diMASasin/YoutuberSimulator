using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private List<GameObject> _windowsToOpen;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        if(_openButton != null)
            _openButton.onClick.AddListener(OpenWindow);
        if (_closeButton != null)
            _closeButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        if (_openButton != null)
            _openButton.onClick.RemoveListener(OpenWindow);
        if (_closeButton != null)
            _closeButton.onClick.RemoveListener(CloseWindow);
    }

    public void OpenWindow()
    {
        foreach (var window in _windowsToOpen)
        {
           window.SetActive(true);
        }
    }

    public void CloseWindow()
    {
        foreach (var window in _windowsToOpen)
        {
            window.SetActive(false);
        }
    }
}
