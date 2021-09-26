using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Заморозка/разморозка времени при включении/выключении объекта
/// </summary>
public class FreezeTime : MonoBehaviour
{
    [SerializeField]
    private bool freezeOnEnable = true;

    private float prevTime = 1f;

    private void OnEnable()
    {
        ChangeTime(freezeOnEnable);
    }

    private void OnDisable()
    {
        ChangeTime(!freezeOnEnable);
    }

    private void ChangeTime(bool freeze)
    {
        if (freeze)
        {
            prevTime = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = prevTime;
        }
    }
}
