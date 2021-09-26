using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пример возврата объекта в пул
/// </summary>
public class ExampleObjectRemover : MonoBehaviour
{
    [SerializeField]
    private float delay = 1f;

    private Coroutine coroutine;

    private void OnEnable()
    {
        coroutine = StartCoroutine(RemoveObjectWithDelay(delay));
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        BackToPool();
    }

    private IEnumerator RemoveObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        BackToPool();
    }

    private void BackToPool()
    {
        if (TryGetComponent(out PoolInformation info))
        {
            info.ObjectPool.FreeObject(gameObject);
        }
    }
}
