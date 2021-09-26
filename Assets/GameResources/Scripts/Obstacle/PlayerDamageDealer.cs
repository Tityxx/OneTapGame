using UnityEngine;

/// <summary>
/// Компонент по нанесению урона игроку
/// </summary>
public class PlayerDamageDealer : AbstractPlayerCollision
{
    [SerializeField]
    private int damage = 1;

    protected override void DoAction(PlayerController player)
    {
        player.HealthController.Health -= damage;
    }
}
