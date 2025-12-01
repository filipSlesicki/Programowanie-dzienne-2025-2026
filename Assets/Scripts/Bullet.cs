using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    public string ignoreTag;
    [HideInInspector]
    public int damage = 1;
    [Header("Explosion")]
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionRadius;
    [SerializeField] LayerMask targetLayers;
    [SerializeField] int explosionDamage;

    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!string.IsNullOrEmpty(ignoreTag) && other.CompareTag(ignoreTag))
        {
            return;
        }
        Destroy(gameObject);
        Health obstacle = other.GetComponent<Health>(); 
        // jak na trafionym obiekcie nie ma komponentu Obstacle, to obstacle jest nullem (nie istnieje)
        if(obstacle != null)
        {
            obstacle.TakeDamage(1);
        }
        if (explosion)
        {
            GameObject spawnedExplosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(spawnedExplosion,1);
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explosionRadius, targetLayers);
            for(int i = 0; i < collidersInRange.Length; i++)
            {
                Health health = collidersInRange[i].GetComponent<Health>();
                if(health)
                {
                    health.TakeDamage(explosionDamage);
                }
            }
        }

    }
}
