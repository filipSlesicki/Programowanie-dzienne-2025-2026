using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static event Action OnEnemyDeath;
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    public static void DoSomething()
    {

    }
}
