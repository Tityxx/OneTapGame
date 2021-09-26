using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Контроллер пула объектов
/// </summary>
public class ObjectPoolController : MonoBehaviour
{
    public static ObjectPoolController Instance;
    public event Action OnPoolInit = delegate { };
    public bool IsInited = false;

    [SerializeField]
    private PrefabWrapper[] prefabs;

    private Dictionary<string, Queue<GameObject>> queue = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        Instance = this;
        InitPool();
        IsInited = true;
        OnPoolInit();
    }

    private void InitPool()
    {
        foreach (PrefabWrapper prefab in prefabs)
        {
            queue.Add(prefab.Id, new Queue<GameObject>());
            for (int i = 0; i < prefab.Count; i++)
            {
                GameObject go = Instantiate(prefab.Prefab);
                go.SetActive(false);

                AddPoolInformation(go, prefab.Id);

                queue[prefab.Id].Enqueue(go);
            }
        }
    }

    public GameObject CreateObject(string id, Vector3 position)
    {
        GameObject go;

        if (queue[id].Count > 0)
        {
            go = queue[id].Dequeue();
        }
        else
        {
            go = Instantiate(FindPrefabById(id));
            AddPoolInformation(go, id);
        }
        go.transform.position = position;
        go.SetActive(true);
        return go;
    }

    public bool FreeObject(GameObject go)
    {
        if (go.TryGetComponent(out PoolInformation info))
        {
            go.SetActive(false);
            go.transform.parent = null;
            queue[info.Id].Enqueue(go);
            return true;
        }
        return false;
    }

    private GameObject FindPrefabById(string id)
    {
        foreach (PrefabWrapper prefab in prefabs)
        {
            if (prefab.Id.Equals(id))
            {
                return prefab.Prefab;
            }
        }
        return null;
    }

    private void AddPoolInformation(GameObject go, string id)
    {
        PoolInformation poolInfo = go.AddComponent<PoolInformation>();
        poolInfo.ObjectPool = this;
        poolInfo.Id = id;
    }

    [Serializable]
    private class PrefabWrapper
    {
        public string Id;
        public int Count;
        public GameObject Prefab;
    }
}
