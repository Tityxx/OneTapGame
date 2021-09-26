using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ¬ключение рандомного объекта из списка и выключение остальных
/// </summary>
public class RandomObject : MonoBehaviour
{
    [SerializeField]
    private List<ListObjects> objects;

    private void OnEnable()
    {

        for (int j = 0; j < objects.Count; j++)
        {
            int rand = UnityEngine.Random.Range(0, objects[j].Objects.Count);

            for (int i = 0; i < objects[j].Objects.Count; i++)
            {
                objects[j].Objects[i].SetActive(i == rand);
            }
        }
    }

    [Serializable]
    private class ListObjects
    {
        public List<GameObject> Objects;
    }
}
