using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausManager : MonoBehaviour
{
    private bool _paused = false;

    public void PausGame()
    {
        if (!_paused)
        {
            Time.timeScale = 0;
            _paused = true;
        }
    }

    public void StartGame()
    {
        if (_paused)
        {
            Time.timeScale = 1;
            _paused = false;
        }
    }
}
