using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �� ���������
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public static event Action<int> OnPlayerChangeHealth = delegate { };

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (invulnerable)
            {
                return;
            }
            if (shield.isActivated)
            {
                shield.DisactivateShield();
                return;
            }
            if (value < health)
            {
                StartCoroutine(DoInvulnerable());
            }
            health = Mathf.Clamp(value, int.MinValue, maxHealth);
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
