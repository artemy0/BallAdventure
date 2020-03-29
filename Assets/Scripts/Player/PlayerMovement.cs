using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _constrainedCenter;

    [Range(0, 100)]
    [SerializeField] private int percentIncreaseSpeed;
    [SerializeField] private float _forwardSpeed, _deflectionSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SwipeController.SwipeEvent += RejectPlayer;

        RaceController.CirclePassed += IncreaseSpeed;
    }

    private void OnDestroy()
    {
        SwipeController.SwipeEvent -= RejectPlayer;

        RaceController.CirclePassed -= IncreaseSpeed;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity += _constrainedCenter.forward * _forwardSpeed * Time.fixedDeltaTime;
    }

    private void IncreaseSpeed()
    {
        _forwardSpeed += _forwardSpeed * percentIncreaseSpeed / 100;
    }

    private void RejectPlayer(SwipeController.SwipeType type)
    {
        switch (type)
        {
            case SwipeController.SwipeType.LEFT:
                _rigidbody.velocity += -_constrainedCenter.right * _deflectionSpeed * Time.deltaTime;
                break;
            case SwipeController.SwipeType.RIGHT:
                _rigidbody.velocity += _constrainedCenter.right * _deflectionSpeed * Time.deltaTime;
                break;
        }
    }
}
