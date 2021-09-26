using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер хп персонажа
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public static event Action<int> OnPlayerChangeHealth = delegate { };

    public int MaxHealth => maxHealth;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (invulnerable && health > value)
            {
                return;
            }
            if (shield.isActivated && health > value)
            {
                shield.DisactivateShield();
                return;
            }
            if (value < health)
            {
                StartCoroutine(DoInvulnerable());
            }
            int prevHp = health;
            health = Mathf.Clamp(value, 0, maxHealth);
            OnPlayerChangeHealth(health);
            if (health <= 0)
            {
                player.Die();
            }
        }
    }

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private ReceiveShield shield;
    [SerializeField]
    private Animation animInvulnerable;
    [SerializeField]
    private MeshRenderer mesh;
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private int maxHealth = 5;
    [SerializeField]
    private float timeToInvulnerable = 1;

    private bool invulnerable = false;

    private IEnumerator DoInvulnerable()
    {
        invulnerable = true;
        animInvulnerable.Play();

        yield return new WaitForSecondsRealtime(timeToInvulnerable);

        invulnerable = false;
        animInvulnerable.Stop();
        mesh.enabled = true;
    }
}
