using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Health obstacle = other.GetComponent<Health>(); 
        // jak na trafionym obiekcie nie ma komponentu Obstacle, to obstacle jest nullem (nie istnieje)
        if(obstacle != null)
        {
            obstacle.TakeDamage(2);
        }
    }
}
