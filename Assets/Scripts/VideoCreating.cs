using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class VideoCreating : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _stageNameText;
    [SerializeField] private Transform _container;
    [SerializeField] private float[] _stageDurations;
    [SerializeField] private string[] _stageNames;
    [SerializeField] private Button _nextStageButton;

    private VideoView _videoViewTemplate;
    private Video _video;
    private Timer _timer;
    private int _developmentStage = -1;

    private void Awake()
    {
        _timer = GetComponentInChildren<Timer>();
    }

    private void LateUpdate()
    {
        if (_timer.IsOn)
            _progressBar.fillAmount = _timer.NormalizedValue;
    }

    private void OnEnable()
    {
        _nextStageButton.onClick.AddListener(NextStage);
    }

    private void OnDisable()
    {
        _nextStageButton.onClick.RemoveListener(NextStage);
    }

    private void Init(VideoView videoViewTemplate, Video video)
    {
        _videoViewTemplate = videoViewTemplate;
        _video = video;
    }

    private void NextStage()
    {
        if (_timer.IsOn)
            return;

        _developmentStage++;
        if (_developmentStage >= _stageDurations.Length)
        {
            FinishVideo();
            return;
        }

        if (_developmentStage < 0)
            throw new IndexOutOfRangeException("_developmentStage < 0");

        _stageNameText.text = _stageNames[_developmentStage];
        _timer.StartTimer(_stageDurations[_developmentStage]);
    }

    private void FinishVideo()
    {
        _developmentStage = -1;
        _timer.Reset();
        _progressBar.fillAmount = 0;

        VideoView newVideoView = Instantiate(_videoViewTemplate, _container);
        newVideoView.transform.SetAsFirstSibling();
        _player.MakeVideo(_video.Subscriptions, _video.Income, _video.MakeVideoDuration);
        gameObject.SetActive(false);
    }

    public void StartCreateVideo(VideoView videoViewTemplate, Video video)
    {
        Init(videoViewTemplate, video);
        NextStage();
    }
}
