using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт для хранения id объекта и ссылки на пул.
/// Добавляется на каждый объект при инициализации пула.
/// </summary>
public class PoolInformation : MonoBehaviour
{
    public ObjectPoolController ObjectPool;
    public string Id;
}
