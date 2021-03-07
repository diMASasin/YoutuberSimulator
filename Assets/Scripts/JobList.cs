using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobList : MonoBehaviour
{
    [SerializeField] private List<Job> _jobs;
    [SerializeField] private JobItem _template;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;

    private void Start()
    {
        foreach (var job in _jobs)
        {
            AddItem(job);
        }
    }

    private void AddItem(Job job)
    {
        JobItem jobItem = Instantiate(_template, _container);
        InitializeItem(jobItem, job);
    }

    private void InitializeItem(JobItem jobItem, Job job)
    {
        jobItem.SetJob(job);
        jobItem.GetJobButtonClick += OnGetJobButtonClick;

    }

    private void OnGetJobButtonClick(Job job, JobItem jobItem)
    {
        _player.GetJob(job);
    }
}
