using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdItem : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _views;

    private Ad _ad;

    public event UnityAction<Ad, AdItem> BuyButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClick?.Invoke(_ad, this);
    }

    public void SetAd(Ad ad)
    {
        _ad = ad;
        RenderAd(ad);
    }

    private void RenderAd(Ad ad)
    {
        _icon.sprite = ad.Icon;
        _label.text = ad.Label;
        _price.text = ad.Price.ToString();
        _views.text = "+" + ad.NotRandomizatedViews.ToString() + " views";
    }
}