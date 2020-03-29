using UnityEngine;

public class Player : MonoBehaviour
{
    public static System.Action OnDeath;

    public void Die()
    {
        OnDeath?.Invoke();
    }
}
