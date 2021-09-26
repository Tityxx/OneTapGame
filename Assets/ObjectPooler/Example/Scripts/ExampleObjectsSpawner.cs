using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пример спавна объектов
/// </summary>
public class ExampleObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private ObjectPoolController poolController;

    [SerializeField]
    private float spawnDelay = 1;

    [SerializeField]
    private Transform redPos;
    [SerializeField]
    private Transform bluePos;
    [SerializeField]
    private Transform greenPos;

    private IEnumerator Start()
    {
        while (true)
        {
            poolController.CreateObject("Red", redPos.position);
            poolController.CreateObject("Blue", bluePos.position);
            poolController.CreateObject("Green", greenPos.position);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
