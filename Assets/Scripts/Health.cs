using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] TMP_Text healthText;
    [SerializeField] UnityEvent onDestroy;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Took {damage} damage. current health is {health}");
        UpdateUI();
        if (health <= 0)
        {
            onDestroy?.Invoke();
        }
    }

    private void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }
}
