using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class JobView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _salary;
    [SerializeField] private TMP_Text _workTime;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _checkMark;
    [SerializeField] private Button _getJob;

    private Job _job;

    public event UnityAction<Job, JobView> GetJobButtonClick;

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

    public void ShowCheckMark()
    {
        _checkMark.gameObject.SetActive(true);
    }

    public void HideCheckMark()
    {
        _checkMark.gameObject.SetActive(false);
    }

    private void RenderJob(Job job)
    {
        _label.text = job.Label;
        _salary.text = job.Salary.ToString() + "$";
        _workTime.text = job.WorkTime.ToString() + "h / day";
        _icon.sprite = job.Icon;
    }
}
