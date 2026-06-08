using System.Collections.Generic;
using TowerDefence;
using UnityEngine;

public class ObjectPoolingSystem : MonoBehaviour
{
    private Dictionary<GameObject, ObjectPool> objectPools = new();
    public static ObjectPoolingSystem Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject Get(GameObject objectType, Vector3 position, Quaternion rotation)
    {
        if(objectPools.TryGetValue(objectType, out ObjectPool pool))
        {
            return pool.Get(position, rotation);
        }
        else
        {
            pool = new(objectType);
            objectPools.Add(objectType, pool);
            return pool.Get(position, rotation);
        }
    }
}
