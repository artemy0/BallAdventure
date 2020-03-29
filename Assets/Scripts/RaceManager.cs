using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static System.Action<RaceManager> OnSave;

    public static System.Action OnCirclePassed;

    public float RaceProgress { get { return _passedAngle / _fullCircleAngle; } }
    public float PassedDistance { get; private set; }
    public float TimeSiceStart { get; private set; }
    public int ObstaclesCount { get { return _obstaclesStorage.childCount; } }

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _planet;

    [SerializeField] private Transform _obstaclesStorage;

    private float _fullCircleAngle = 360f; //кругом вокруг планеты считается прохождение по ней пути в 360 градусов
    private float _passedAngle;

    private Vector3 previousPlayerPosition;

    private void Start()
    {
        PassedDistance = 0f;
        TimeSiceStart = 0f;

        _passedAngle = 0f;

        previousPlayerPosition = _player.position;
    }

    private void Update()
    {
        TimeSiceStart += Time.deltaTime;

        float angle = GetPlanetaryAngle(previousPlayerPosition, _player.position);
        _passedAngle += angle;

        PassedDistance += Vector3.Distance(previousPlayerPosition, _player.position);

        if (_passedAngle > _fullCircleAngle)
        {
            OnCirclePassed?.Invoke();
            _passedAngle = 0f;
        }

        OnSave?.Invoke(this);

        previousPlayerPosition = _player.position;
    }

    private float GetPlanetaryAngle(Vector3 from, Vector3 to)
    {
        Vector3 previousPlanetPlayerVector = from - _planet.position;
        Vector3 currentPlanetPlayerVector = to - _planet.position;

        return Vector3.Angle(previousPlanetPlayerVector, currentPlanetPlayerVector);
    }
}
