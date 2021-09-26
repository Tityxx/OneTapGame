using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Рандомный спаун объекта 
/// </summary>
public class RandomPercentSpawn : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private float chance;

    private void OnEnable()
    {
        int rand = Random.Range(0, 101);
        gameObject.SetActive(rand <= chance);
    }
}
