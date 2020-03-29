using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;

    [SerializeField] private float _gravityForce;

    private void FixedUpdate()
    {
        //Гравитация (сила действующая на игрока со стороны планеты)
        Vector3 directionToPlanet = (transform.position - _player.position).normalized;
        _player.velocity += directionToPlanet * _gravityForce * Time.fixedDeltaTime;
    }
}
