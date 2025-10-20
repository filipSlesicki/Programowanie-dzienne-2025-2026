using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Obstacle obstacle = other.GetComponent<Obstacle>();
        obstacle.health--;
        if(obstacle.health <=0)
        {
            Destroy(obstacle.gameObject);
        }
    }
}
