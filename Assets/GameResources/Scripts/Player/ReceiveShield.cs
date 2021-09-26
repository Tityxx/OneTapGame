using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Активация/деактивация щита щита
/// </summary>
public class ReceiveShield : MonoBehaviour
{
    public static event Action<float> OnPlayerActivateShield = delegate { };

    public bool isActivated = false;

    [SerializeField]
    private GameObject activatedShield;
    [SerializeField]
    private float shieldTime = 10;

    private Coroutine coroutine;

    /// <summary>
    /// Активация щита
    /// </summary>
    public void ActivateShield()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(StartActivate());
    }

    /// <summary>
    /// Деактивация щита
    /// </summary>
    public void DisactivateShield()
    {
        activatedShield.SetActive(false);
        isActivated = false;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator StartActivate()
    {
        isActivated = true;
        activatedShield.SetActive(true);
        OnPlayerActivateShield(shieldTime);

        yield return new WaitForSeconds(shieldTime);

        DisactivateShield();
    }
}
