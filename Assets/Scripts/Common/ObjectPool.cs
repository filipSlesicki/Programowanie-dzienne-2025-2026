using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class ObjectPool
    {
        public static ObjectPool Instance;
        private GameObject prefab;
        private Stack<GameObject> freeObjectPool = new Stack<GameObject>();

        public ObjectPool(GameObject prefab, int initialPoolSize = 10)
        {
            this.prefab = prefab;
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject pooledObject = GameObject.Instantiate(prefab);
                pooledObject.SetActive(false);
                pooledObject.GetComponent<IPoolable>().SetPool(this);
                freeObjectPool.Push(pooledObject);
            }
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            if (freeObjectPool.Count == 0)
            {
                GameObject pooledObject = GameObject.Instantiate(prefab, position, rotation);
                return pooledObject;
            }
            GameObject obj = freeObjectPool.Pop();
            obj.GetComponent<IPoolable>().SetPool(this);
            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);
            return obj;
        }

        public void Release(GameObject obj)
        {
            obj.SetActive(false);
            freeObjectPool.Push(obj);
        }

    }
}
