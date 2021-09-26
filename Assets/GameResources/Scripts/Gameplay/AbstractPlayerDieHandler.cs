using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������� ����� ��� ���������� 
/// ������� � ������ ������
/// </summary>
public abstract class AbstractPlayerDieHandler : MonoBehaviour
{
    protected virtual void Awake()
    {
        PlayerController.OnPlayerDie += OnPlayerDie;
    }

    protected virtual void OnDestroy()
    {
        PlayerController.OnPlayerDie -= OnPlayerDie;
    }

    protected abstract void OnPlayerDie();
}
