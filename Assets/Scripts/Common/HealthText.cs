using System;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] Health health;

    void OnEnable()
    {
        health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health, int maxHealth)
    {
        healthText.text = $"{health}/{maxHealth}";
    }
}
