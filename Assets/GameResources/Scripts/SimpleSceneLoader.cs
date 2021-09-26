using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Загрузчик сцены по клику на кнопку
/// </summary>
public class SimpleSceneLoader : AbstractButton
{
    [SerializeField]
    private string sceneName = string.Empty;

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
