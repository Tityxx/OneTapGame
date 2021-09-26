using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ��
/// </summary>
public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private GameObject activeHealth;

    /// <summary>
    /// ����� ��������� ��
    /// </summary>
    /// <param name="isActive"></param>
    public void ChangeHealthState(bool isActive)
    {
        activeHealth.SetActive(isActive);
    }
}
