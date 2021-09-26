using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Изменение скорости времени
/// </summary>
public class TimeItem : AbstractPlayerCollision
{
    public static event Action<bool, float> OnChangeTimeScale = delegate { };
    public static event Action OnEndBonus = delegate { };

    [SerializeField]
    private GameObject mesh;
    [SerializeField]
    private Collider collider;

    [SerializeField, Header("Ускорить или замедлить время")]
    private bool slowDown = true;
    [SerializeField]
    private float duration = 3;
    [SerializeField]
    private float slowTime = 0.5f;
    [SerializeField]
    private float fastTime = 1.5f;

    private static Coroutine coroutine = null;

    private void Awake()
    {
        transform.parent = null;
    }

    private void OnDestroy()
    {
        StopCoroutine();
    }

    protected override void DoAction(PlayerController player)
    {
        StopCoroutine();
        coroutine = StartCoroutine(DoBonus());
    }

    private IEnumerator DoBonus()
    {
        OnChangeTimeScale(slowDown, duration);
        Time.timeScale = slowDown ? slowTime : fastTime;

        mesh.SetActive(false);
        collider.enabled = false;

        yield return new WaitForSecondsRealtime(duration);

        Destroy(gameObject);
    }

    private void StopCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            Time.timeScale = 1;
            OnEndBonus();
        }
    }
}
