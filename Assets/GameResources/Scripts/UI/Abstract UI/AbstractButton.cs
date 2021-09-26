using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Абстрактый класс кнопки
/// </summary>
[RequireComponent(typeof(Button))]
public abstract class AbstractButton : MonoBehaviour
{
    protected Button btn;

    protected virtual void Awake()
    {
        btn = GetComponent<Button>();
    }

    protected virtual void OnEnable()
    {
        btn.onClick.AddListener(OnButtonClick);
    }

    protected virtual void OnDisable()
    {
        btn.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}
