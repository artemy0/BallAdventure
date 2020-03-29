using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStatistics : MonoBehaviour
{
    public static System.Action<RaceStatistics> OnSave;

    [SerializeField] private Transform _obstaclesStorage;

    public float timeSiceStart { get; private set; }
    public int obstaclesCount { get { return _obstaclesStorage.childCount; } }

    private void Start()
    {
        timeSiceStart = 0f;
    }

    private void Update()
    {
        timeSiceStart += Time.deltaTime;
        OnSave?.Invoke(this);
    }
}
