using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsShop : MonoBehaviour
{
    [SerializeField] private List<Ad> _ads;
    [SerializeField] private Player _player;
    [SerializeField] private AdView _template;
    [SerializeField] private Transform _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _ads.Count; i++)
        {
            AddAd(_ads[i]);
        }
    }

    private void AddAd(Ad ad)
    {
        AdView AdItem = Instantiate(_template, _itemContainer);
        InitializeAd(AdItem, ad);
    }

    private void InitializeAd(AdView AdItem, Ad ad)
    {
        AdItem.SetAd(ad);
        AdItem.BuyButtonClick += OnBuyButtonClick;

    }

    private void OnBuyButtonClick(Ad ad, AdView AdItem)
    {
        TrySellAd(ad, AdItem);
    }

    private void TrySellAd(Ad ad, AdView AdItem)
    {
        if (_player.CheckSolvency(ad.Price))
        {
            _player.BuyAd(ad);
        }
    }
}
