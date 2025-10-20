using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 1;

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
