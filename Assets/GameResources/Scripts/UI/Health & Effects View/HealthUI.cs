using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Элемент хп
/// </summary>
public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private GameObject activeHealth;

    /// <summary>
    /// Смена состояния хп
    /// </summary>
    /// <param name="isActive"></param>
    public void ChangeHealthState(bool isActive)
    {
        activeHealth.SetActive(isActive);
    }
}
