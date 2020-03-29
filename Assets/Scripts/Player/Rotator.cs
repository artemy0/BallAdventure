using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        SwipeController.SwipeEvent += RotateCenter;
    }

    private void OnDestroy()
    {
        SwipeController.SwipeEvent -= RotateCenter;
    }

    private void RotateCenter(SwipeController.SwipeType type)
    {
        switch (type)
        {
            case SwipeController.SwipeType.LEFT:
                transform.RotateAround(transform.position, transform.up, -_rotationSpeed * Time.deltaTime);
                break;
            case SwipeController.SwipeType.RIGHT:
                transform.RotateAround(transform.position, transform.up, _rotationSpeed * Time.deltaTime);
                break;
        }
    }
}
