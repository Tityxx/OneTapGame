using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предмет щита.
/// </summary>
public class ShieldItem : AbstractPlayerCollision
{
    protected override void DoAction(PlayerController player)
    {
        if (player.TryGetComponent(out ReceiveShield shield))
        {
            shield.ActivateShield();
            Destroy(gameObject);
        }
    }
}
