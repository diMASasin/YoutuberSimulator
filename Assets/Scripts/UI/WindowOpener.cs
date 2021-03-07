using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private GameObject _windowToOpen;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OpenWindow);
        _closeButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(OpenWindow);
        _closeButton.onClick.RemoveListener(CloseWindow);
    }

    public void OpenWindow()
    {
        _windowToOpen.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        _windowToOpen.gameObject.SetActive(false);
    }
}
