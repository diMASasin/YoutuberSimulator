using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Ad> _ads;
    [SerializeField] private Player _player;
    [SerializeField] private AdItem _template;
    [SerializeField] private Transform _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _ads.Count; i++)
        {
            AddItem(_ads[i]);
        }    
    }

    private void AddItem(Ad ad)
    {
        AdItem AdItem = Instantiate(_template, _itemContainer);
        InitializeItem(AdItem, ad);
    }

    private void InitializeItem(AdItem AdItem, Ad ad)
    {
        AdItem.SetAd(ad);
        AdItem.BuyButtonClick += OnBuyButtonClick;

    }

    private void OnBuyButtonClick(Ad ad, AdItem AdItem)
    {
        TrySellAd(ad, AdItem);
    }

    private void TrySellAd(Ad ad, AdItem AdItem)
    {
        if (_player.CheckSolvency(ad.Price))
        {
            _player.BuyAd(ad);

        }
    }
}
