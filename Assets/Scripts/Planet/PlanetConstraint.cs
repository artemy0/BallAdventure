using UnityEngine;

public class PlanetConstraint : MonoBehaviour
{
    [SerializeField] private Transform _targetPlanet;

    private void FixedUpdate()
    {
        //Поворот объекта к которому прикреплён скрипт к центру планеты
        Quaternion rotation = Quaternion.FromToRotation(-transform.up, _targetPlanet.position - transform.position);
        transform.rotation = rotation * transform.rotation;
    }
}
