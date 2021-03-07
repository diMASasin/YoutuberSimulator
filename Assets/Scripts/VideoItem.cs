using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _subscriptions;
    [SerializeField] private TMP_Text _views;
    [SerializeField] private TMP_Text _income;
    [SerializeField] private Image _icon;

    private Video _video;

    public void SetVideo(Video video)
    {
        _video = video;
        RenderVideo(video);

    }

    public void RenderVideo(Video video)
    {
        _label.text = video.Name;
        _subscriptions.text = video.Subscriptions.ToString();
        _views.text = video.Views.ToString();
        _income.text = video.Income.ToString();
        _icon.sprite = video.Icon;
    }
}
