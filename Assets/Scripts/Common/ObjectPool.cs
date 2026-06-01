using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialPoolSize = 10;
        private Stack<GameObject> freeObjectPool = new Stack<GameObject>();


        private void Start()
        {
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject pooledObject = Instantiate(prefab);
                pooledObject.SetActive(false);
                freeObjectPool.Push(pooledObject);
            }
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            if (freeObjectPool.Count == 0)
            {
                GameObject pooledObject = Instantiate(prefab, position, rotation);
                return pooledObject;
            }
            GameObject obj = freeObjectPool.Pop();
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
