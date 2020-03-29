using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static System.Action GameOver;

    public void Die()
    {
        GameOver?.Invoke();
    }
}
