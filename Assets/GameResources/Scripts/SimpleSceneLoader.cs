using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������� ����� �� ����� �� ������
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
