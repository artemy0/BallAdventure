using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    //Работа с прогрессом, её необходимо перенести сюда
    public static System.Action<ProgressManager> OnUpdate;

    public float raceProgress { get; private set; }
    public int distanceSiceStart { get; private set; }
    public int secondsSiceStart { get; private set; }
    public int obstaclesCount { get; private set; }

    private void Update()
    {
        OnUpdate?.Invoke(this);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            Debug.Log("1 scene was loaded.");

            RaceController.OnSave += SaveRaceProgress;

            RaceStatistics.OnSave += SaveRaceStatistics;
        }
        if(level == 2)
        {
            Debug.Log("2 scene was loaded.");

            RaceController.OnSave -= SaveRaceProgress;

            RaceStatistics.OnSave -= SaveRaceStatistics;
        }
    }

    private void SaveRaceProgress(RaceController race)
    {
        raceProgress = race.GetRaceProgress();
        distanceSiceStart = (int)race.GetPassedDistance();
    }

    private void SaveRaceStatistics(RaceStatistics race)
    {
        secondsSiceStart = (int)race.timeSiceStart;
        obstaclesCount = race.obstaclesCount;
    }
}
