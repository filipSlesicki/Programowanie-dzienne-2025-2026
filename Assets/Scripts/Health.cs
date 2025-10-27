using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] TMP_Text healthText;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateUI();
        if (health <= 0)
        {
            Destroy(gameObject);
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
