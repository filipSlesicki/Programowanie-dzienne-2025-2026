using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
