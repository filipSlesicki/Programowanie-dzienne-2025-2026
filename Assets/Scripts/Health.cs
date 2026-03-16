using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public event Action<int, int> HealthChanged;
    [SerializeField] private int maxHealth = 1;
    [SerializeField] UnityEvent onDestroy;
    private int health = 1;

    private void Start()
    {
        health = maxHealth;
        HealthChanged?.Invoke(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Took {damage} damage. current health is {health}");
        HealthChanged?.Invoke(health, maxHealth);
        if (health <= 0)
        {
            onDestroy?.Invoke();
        }
    }
}
