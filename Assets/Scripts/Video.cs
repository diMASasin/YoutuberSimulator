using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Video : MonoBehaviour
{
    public string Name { get; private set; }
    public int Views { get; private set; }
    public int Income { get; private set; }
    public int Subscriptions { get; private set; }
    public Sprite Icon { get; private set; }
    public int MakeVideoDuration { get; private set; } = 6;



    public void Initialize(Player player, TMP_InputField videoName)
    {
        Name = videoName.text;
        videoName.text = "";

        Views = Random.Range(1, 30) + player.ViewsBonus + player.Subscribers;
        player.ResetBonus();

        if (Views / 100 == 0)
        {
            int randomNumber = Random.Range(0, 9);

            if (randomNumber == 3)
                Subscriptions = 2;
            else if (randomNumber < 3)
                Subscriptions = 1;

        }
        else
        {
            Subscriptions = Views / 100;
            Subscriptions += Random.Range(-1, 2);
        }

        Income = Views / 1000;
    }
}
