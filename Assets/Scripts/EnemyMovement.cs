using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
