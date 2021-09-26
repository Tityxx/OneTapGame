using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������� ������� ���������
/// </summary>
public class LoseListener : AbstractPlayerDieHandler
{
    [SerializeField]
    private GameObject loseWindow;
    [SerializeField]
    private GameObject gameWindow;

    protected override void OnPlayerDie()
    {
        loseWindow.SetActive(true);
        gameWindow.SetActive(false);
    }
}
