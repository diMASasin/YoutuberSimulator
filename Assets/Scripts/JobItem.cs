using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class JobItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _salary;
    [SerializeField] private TMP_Text _workTime;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _getJob;

    private Job _job;

    public event UnityAction<Job, JobItem> GetJobButtonClick;

    private void OnEnable()
    {
        _getJob.onClick.AddListener(OnGetJobButtonClick);
    }

    private void OnDisable()
    {
        _getJob.onClick.RemoveListener(OnGetJobButtonClick);
    }

    private void OnGetJobButtonClick()
    {
        GetJobButtonClick?.Invoke(_job, this);
    }

    public void SetJob(Job job)
    {
        _job = job;
        RenderJob(job);
    }

    private void RenderJob(Job job)
    {
        _label.text = job.Label;
        _salary.text = job.Salary.ToString();
        _workTime.text = job.WorkTime.ToString() + "h";
        _icon.sprite = job.Icon;
    }
}
