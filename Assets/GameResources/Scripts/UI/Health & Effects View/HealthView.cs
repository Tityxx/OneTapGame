using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¬ью дл€ здоровь€
/// </summary>
public class HealthView : MonoBehaviour
{
    [SerializeField]
    private HealthUI healthPrefab;

    private List<HealthUI> healthList = new List<HealthUI>();
    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();

        for (int i = 0; i < player.HealthController.MaxHealth; i++)
        {
            HealthUI health = Instantiate(healthPrefab, transform);
            healthList.Add(health);
            health.ChangeHealthState(i < player.HealthController.Health);
        }
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerChangeHealth += ChangeHealthState;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerChangeHealth -= ChangeHealthState;
    }

    private void ChangeHealthState(int currHealth)
    {
        for (int i = 0; i < healthList.Count; i++)
        {
            healthList[i].ChangeHealthState(i < currHealth);
        }
    }
}
