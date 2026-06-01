using System.Collections.Generic;
using System.Linq;
using Codice.CM.Common;
using TowerDefence;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    public float bulletSpeed;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        MoveBullets();
    }

    void MoveBullets()
    {
        int count = Bullet.bullets.Count;
        Transform[] bulletTransforms = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            bulletTransforms[i] = Bullet.bullets[i].transform;
        }
        TransformAccessArray transformAccessArray = new TransformAccessArray(bulletTransforms);
        float deltaTime = Time.deltaTime;
        MoveBulletsJob job = new MoveBulletsJob() { speed = bulletSpeed, deltaTime = Time.deltaTime };
        JobHandle jobHandle = job.ScheduleByRef(transformAccessArray);
        jobHandle.Complete();
        transformAccessArray.Dispose();
    }
}
