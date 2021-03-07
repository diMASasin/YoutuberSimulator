using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Studio : MonoBehaviour
{
    [SerializeField] private Button _makeVideoButton;
    [SerializeField] private Studio _studio;
    [SerializeField] private VideoItem _videoItemTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private TMP_InputField _videoName;
    [SerializeField] private Player _player;

    private List<Video> _videos = new List<Video>();

    private void OnEnable()
    {
        _makeVideoButton.onClick.AddListener(MakeVideo);
    }

    private void OnDisable()
    {
        _makeVideoButton.onClick.RemoveListener(MakeVideo);
    }

    private void MakeVideo()
    {
        Video newVideo = gameObject.AddComponent<Video>();

        if (!_player.IsEnoughTime(newVideo.MakeVideoDuration))
            return;

        newVideo.Initialize(_player, _videoName);

        _videoItemTemplate.SetVideo(newVideo);
        _videos.Add(newVideo);

        VideoItem newVideoItem = Instantiate(_videoItemTemplate, _container);
        newVideoItem.transform.SetAsFirstSibling();

        _player.MakeVideo(newVideo.Subscriptions, newVideo.Income, newVideo.MakeVideoDuration);
    }
}

