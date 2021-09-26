using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Абстрактный класс столкновение объекта с игроком
/// </summary>
[RequireComponent(typeof(Collider))]
public abstract class AbstractPlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.TryGetComponent(out PlayerController player))
        {
            DoAction(player);
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.TryGetComponent(out PlayerController player))
        {
            DoAction(player);
        }
    }

    protected abstract void DoAction(PlayerController player);
}
