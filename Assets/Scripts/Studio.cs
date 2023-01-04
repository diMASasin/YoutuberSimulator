using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Studio : MonoBehaviour
{
    [SerializeField] private Button _makeVideoButton;
    [SerializeField] private VideoView _videoViewTemplate;
    [SerializeField] private TMP_InputField _videoName;
    [SerializeField] private Player _player;
    [SerializeField] private Video _video;
    [SerializeField] private VideoCreating _videoCreating;
    

    private void Awake()
    {
        _videoName.text = "New video";
    }

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
        if (!_player.IsEnoughTime(_video.MakeVideoDuration))
            return;

        _video.Initialize(_player, _videoName);

        _videoViewTemplate.SetVideo(_video);

        _videoCreating.gameObject.SetActive(true);
        _videoCreating.StartCreateVideo(_videoViewTemplate, _video);
    }
}

