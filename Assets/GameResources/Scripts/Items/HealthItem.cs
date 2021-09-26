using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Добавление здоровья игроку
/// </summary>
public class HealthItem : AbstractPlayerCollision
{
    [SerializeField]
    private int health = 1;

    protected override void DoAction(PlayerController player)
    {
        player.HealthController.Health += health;
        Destroy(gameObject);
    }
}
