using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCanvasGroup : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
       if(_openButton != null)
         _openButton.onClick.AddListener(Open);
       if(_closeButton != null)
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        if(_openButton != null)
            _openButton.onClick.RemoveListener(Open);
        if(_closeButton != null)
            _closeButton.onClick.RemoveListener(Close);
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
