using System;
using UnityEngine;

public class WaitForInit : MonoBehaviour
{
    [SerializeField] private DelegatesTest delegatesTest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        delegatesTest.OnInitialized += OnDelegatesTestInitialized;
    }

    private void OnDelegatesTestInitialized()
    {
        Debug.Log("Other initialized");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
