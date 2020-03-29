using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static System.Action<RaceController> OnSave;

    public static System.Action CirclePassed;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _planet;

    private float _fullCircleAngle = 360f; //кругом вокруг планеты считается прохождение по ней пути в 360 градусов
    private float _passedAngle;
    private float _passedDistance;

    private Vector3 previousPlayerPosition;

    private void Start()
    {
        _passedAngle = 0f;
        previousPlayerPosition = _player.position;
    }

    private void Update()
    {
        float angle = GetPlanetaryAngle(previousPlayerPosition, _player.position);
        _passedAngle += angle;

        _passedDistance += Vector3.Distance(previousPlayerPosition, _player.position);

        if (_passedAngle > _fullCircleAngle)
        {
            CirclePassed?.Invoke();
            _passedAngle = 0f;
        }

        OnSave?.Invoke(this);

        previousPlayerPosition = _player.position;
    }

    public float GetRaceProgress()
    {
        return _passedAngle / _fullCircleAngle;
    }

    public float GetPassedDistance()
    {
        return _passedDistance;
    }

    private float GetPlanetaryAngle(Vector3 from, Vector3 to)
    {
        Vector3 previousPlanetPlayerVector = from - _planet.position;
        Vector3 currentPlanetPlayerVector = to - _planet.position;

        return Vector3.Angle(previousPlanetPlayerVector, currentPlanetPlayerVector);
    }
}
