using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавн эффекта при смерти игрока
/// </summary>
public class DieEffectSpawner : AbstractPlayerDieHandler
{
    [SerializeField]
    private GameObject explosion;

    private PlayerController player;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<PlayerController>();
    }

    protected override void OnPlayerDie()
    {
        Instantiate(explosion, player.transform.position, Quaternion.identity);
    }
}
