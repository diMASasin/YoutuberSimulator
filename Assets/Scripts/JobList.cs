using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobList : MonoBehaviour
{
    [SerializeField] private List<Job> _jobs;
    [SerializeField] private JobView _template;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;

    private void Start()
    {
        foreach (var job in _jobs)
        {
            AddJob(job);
        }
    }

    private void AddJob(Job job)
    {
        JobView jobItem = Instantiate(_template, _container);
        InitializeJob(jobItem, job);
    }

    private void InitializeJob(JobView jobItem, Job job)
    {
        jobItem.SetJob(job);
        jobItem.GetJobButtonClick += OnGetJobButtonClick;

    }

    private void OnGetJobButtonClick(Job job, JobView jobItem)
    {
        _player.GetJob(job);
    }
}
