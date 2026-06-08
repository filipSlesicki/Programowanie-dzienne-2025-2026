using System;
using UnityEngine;

public abstract class BulletCollisionEffect : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Bullet>().OnCollideWithEnemy += OnBulletCollide;
    }

    private void OnDisable()
    {
        GetComponent<Bullet>().OnCollideWithEnemy -= OnBulletCollide;
    }

    protected abstract void OnBulletCollide(Health health);
}
