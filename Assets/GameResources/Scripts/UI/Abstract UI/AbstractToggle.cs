using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Абстрактый класс тоггла
/// </summary>
[RequireComponent(typeof(Toggle))]
public abstract class AbstractToggle : MonoBehaviour
{
    protected Toggle toggle;

    protected virtual void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    protected virtual void OnEnable()
    {
        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    protected virtual void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(OnValueChanged);
    }

    protected abstract void OnValueChanged(bool value);
}
