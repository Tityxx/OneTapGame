using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Разрушение объекта с задержкой
/// </summary>
public class DestroyWithDelay : MonoBehaviour
{
    [SerializeField, Header("Использовать RealTime или Time?")]
    private bool useRealTime = false;
    [SerializeField]
    private float delay = 2;

    private void OnEnable()
    {
        StartCoroutine(WaitForDestroy());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private IEnumerator WaitForDestroy()
    {
        if (useRealTime)
        {
            yield return new WaitForSecondsRealtime(delay);
        }
        else
        {
            yield return new WaitForSeconds(delay);
        }

        Destroy(gameObject);
    }
}
