using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DelegatesTest : MonoBehaviour
{
    public event Action OnInitialized;
    [SerializeField] private Item[] items;
    [SerializeField] public Transform itemsParent;
    [SerializeField] Button buttonPrefab;
    [SerializeField]
    GameObject[] objects;
    Action testDelegate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Item item in items)
        {
            Button spawnedButton = Instantiate(buttonPrefab, itemsParent);
            spawnedButton.onClick.AddListener(() => Debug.Log(item.Name));
        }
        StartCoroutine(DoActionAfterDelay(DoSomething, 3));
        StartCoroutine(DoActionAfterDelay(DoSomething, 5));
        DestroyObject(FindClosestObject);
        OnInitialized?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            testDelegate += DoSomething;
        }
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            testDelegate -= DoSomething;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            testDelegate?.Invoke();
        }
    }

    private IEnumerator DoActionAfterDelay(TestDelegate action,
        float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    void DoSomething()
    {
        Debug.Log("Something");
    }

    GameObject FindClosestObject()
    {
        GameObject closest = null;
        float bestDistance = float.MaxValue;
        foreach (GameObject go in objects)
        {
            float distance = Vector3.Distance(go.transform.position, transform.position);
            if (distance < bestDistance)
            {
                closest = go;
                bestDistance = distance;
            }

        }
        return closest;
    }

    GameObject FindPlayer()
    {
        return GameObject.FindWithTag("Player");
    }

    private void DestroyObject(Func<GameObject> objectSelector)
    {
        GameObject toDestroy = objectSelector();
        if (toDestroy != null)
        {
            Destroy(toDestroy);
        }
    }

}

public delegate void TestDelegate();