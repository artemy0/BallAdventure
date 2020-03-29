using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Slider _raceProgress;
    [SerializeField] private Text _travelDistance;
    [SerializeField] private Text _travelTime;
    [SerializeField] private Text _obstaclesCount;

    private void Start()
    {
        ProgressManager.OnUpdate += UpdateProgress;
    }

    private void OnDestroy()
    {
        ProgressManager.OnUpdate -= UpdateProgress;
    }

    private void UpdateProgress(ProgressManager progress)
    {
        if(_raceProgress != null) //равно null когда мы вызываем его в сцене с результатами
            _raceProgress.value = progress.raceProgress;
        _travelDistance.text = $"{(int)progress.distanceSiceStart} m";
        _travelTime.text = $"{(int)progress.secondsSiceStart} s";
        _obstaclesCount.text = $"{progress.obstaclesCount}";
    }
}
