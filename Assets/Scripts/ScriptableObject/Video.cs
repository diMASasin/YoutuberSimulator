using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Video", menuName ="Video", order = 56)]
public class Video : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _randomizationValue = 0.1f;

    public string Name { get; private set; }
    public int Views { get; private set; }
    public int Income { get; private set; }
    public int Subscriptions { get; private set; }
    public Sprite Icon => _icon;
    public int MakeVideoDuration { get; private set; } = 6;

    private int _videoQuality = 100;

    public void Initialize(Player player, TMP_InputField videoName)
    {
        Name = videoName.text;
        videoName.text = "New video";

        InitializeVideoQuality(player);
        InitializeViews(player);

        Income = Views / 1000;
        Income += Mathf.RoundToInt(Random.Range(-Income * _randomizationValue, Income * _randomizationValue));
    }

    private void InitializeVideoQuality(Player player)
    {
        _videoQuality = 100;

        foreach (var equipmentShop in player.EquipmetShops)
            _videoQuality += equipmentShop.CalculateSumOfValues();

        _videoQuality += player.Skills.CalculateSumOfSkillValues();
    }

    private void InitializeViews(Player player)
    {
        Views = Random.Range(5, 30) + player.Subscribers;
        Views = Mathf.RoundToInt(Views * (float)_videoQuality / 100);
        Views += player.ViewsBonus;
        player.ResetBonus();

        if (Views / 100 == 0)
        {
            int randomNumber = Random.Range(0, 9);

            if (randomNumber == 3)
                Subscriptions = 2;
            else if (randomNumber < 3)
                Subscriptions = 1;
            else
                Subscriptions = 0;
        }
        else
        {
            Subscriptions = Views / 100;
            Subscriptions += Mathf.RoundToInt(Random.Range(-Subscriptions * _randomizationValue, Subscriptions * _randomizationValue));
        }
    }
}
