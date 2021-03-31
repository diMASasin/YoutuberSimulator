using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobList : MonoBehaviour
{
    [SerializeField] private List<Job> _jobs;
    [SerializeField] private Button _quitButton;
    [SerializeField] private JobView _template;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;

    private List<JobView> _jobViews = new List<JobView>();

    private void OnEnable()
    {
        _quitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        _quitButton.onClick.RemoveListener(Quit);
    }

    private void Quit()
    {
        HideAllCheckMarks();
        _player.GetJob(null);
    }

    private void HideAllCheckMarks()
    {
        foreach (var item in _jobViews)
            item.HideCheckMark();
    }

    private void Start()
    {
        foreach (var job in _jobs)
        {
            AddJob(job);
        }
    }

    private void AddJob(Job job)
    {
        JobView jobView = Instantiate(_template, _container);
        _jobViews.Add(jobView);
        InitializeJob(jobView, job);
    }

    private void InitializeJob(JobView jobItem, Job job)
    {
        jobItem.SetJob(job);
        jobItem.GetJobButtonClick += OnGetJobButtonClick;

    }

    private void OnGetJobButtonClick(Job job, JobView jobView)
    {
        HideAllCheckMarks();
        jobView.ShowCheckMark();
        _player.GetJob(job);
    }
}
