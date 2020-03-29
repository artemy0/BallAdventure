using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Slider _raceProgress;
    [SerializeField] private Text _passedDistance;
    [SerializeField] private Text _passedTime;
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
            _raceProgress.value = progress.RaceProgress;

        _passedDistance.text = $"{(int)progress.PassedDistance} m";

        _passedTime.text = $"{(int)progress.PassedTime} s";

        _obstaclesCount.text = $"{progress.ObstaclesCount}";
    }
}
