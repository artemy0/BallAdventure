using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static System.Action<ProgressManager> OnUpdate;

    public float RaceProgress { get; private set; }
    public int PassedDistance { get; private set; }
    public int PassedTime { get; private set; }
    public int ObstaclesCount { get; private set; }

    private void Update()
    {
        OnUpdate?.Invoke(this); //что та надо сделать
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            RaceManager.OnSave += SaveRaceProgress;
        }
        if(level != 1)
        {
            RaceManager.OnSave -= SaveRaceProgress;
        }
    }

    private void SaveRaceProgress(RaceManager race)
    {
        RaceProgress = race.RaceProgress;
        PassedDistance = (int)race.PassedDistance;
        PassedTime = (int)race.TimeSiceStart;
        ObstaclesCount = race.ObstaclesCount;
    }
}
