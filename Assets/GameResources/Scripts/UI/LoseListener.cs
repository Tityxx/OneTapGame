using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обработка события проигрыша
/// </summary>
public class LoseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject loseWindow;
    [SerializeField]
    private GameObject gameWindow;

    private void Awake()
    {
        PlayerController.OnPlayerDie += OnPlayerDie;
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerDie -= OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        loseWindow.SetActive(true);
        gameWindow.SetActive(false);
    }
}
