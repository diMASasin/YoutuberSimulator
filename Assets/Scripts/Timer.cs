using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float _maxTime = 1;

    public bool IsOn { get; private set; }
    public float ElapsedTime { get; private set; }
    public float NormalizedValue { get; private set; }

    public event UnityAction Finished;

    private void Start()
    {
        Reset();
    }

    void Update()
    {
        if(IsOn)
        {
            ElapsedTime += Time.deltaTime;
            NormalizedValue = ElapsedTime / _maxTime;
        }
    }

    private void LateUpdate()
    {
        if (ElapsedTime >= _maxTime)
        {
            ElapsedTime = _maxTime;
            NormalizedValue = 1;
            Stop();
            Finished?.Invoke();
        }
    }

    public void StartTimer(float time)
    {
        Reset();
        _maxTime = time;
        IsOn = true;
    }

    private void Stop()
    {
        IsOn = false;
    }

    public void Reset()
    {
        ElapsedTime = 0;
    }
}
