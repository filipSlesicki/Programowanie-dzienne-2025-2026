using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    public Transform center;
    public float angularSpeed = 30;
    public float radius;
    public float angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        angle += angularSpeed * Time.deltaTime;
        float angleRad = Mathf.Deg2Rad * angle;
        transform.position = center.position + new Vector3(Mathf.Cos(angleRad) * radius, Mathf.Sin(angleRad) * radius, 0);
    }

}
