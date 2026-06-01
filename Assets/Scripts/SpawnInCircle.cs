using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SpawnInCircle : MonoBehaviour
{
    public GameObject prefab;
    public MoveInCircle prefab2;
    public int spawnCount = 5;
    public float spawnRadius = 1;
    public Transform centerRig;
    public float rotationSpeed = 30;
    List<GameObject> spheres = new();


    void Start()
    {
        //SpawnRot();
        SpawnTrig();
    }

    void Update()
    {
        //MoveRot();
        ShootFront();
    }



    void ShootFront()
    {
        List<GameObject> toRemove = new();
        foreach (var sphere in spheres)
        {
            Vector3 toSphere = (sphere.transform.position - transform.position).normalized;

            //if(Vector3.Angle(transform.up, toSphere) < 5)
            if (Vector3.Dot(transform.up, toSphere) > 0.95f)
            {
                Destroy(sphere.gameObject);
                toRemove.Add(sphere);
                Debug.Log("Kill");
            }
        }
        foreach (var destroyed in toRemove)
        {
            spheres.Remove(destroyed);
        }
    }


    void MoveRot()
    {
        centerRig.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    void SpawnTrig()
    {
        float anglePerObject =Mathf.PI*2 / spawnCount;
        for (int i = 0; i <= spawnCount; i++)
        {
            float angle = i * anglePerObject;
            MoveInCircle spawned = Instantiate(prefab2,
                centerRig.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius,
                Quaternion.identity);

            spawned.angle = i * anglePerObject * Mathf.Rad2Deg;
            spawned.center = centerRig;
            spawned.radius = spawnRadius;
            spheres.Add(spawned.gameObject);
        }
    }

    void SpawnRot()
    {
        float anglePerObject = 360f / spawnCount;
        for (int i = 0; i <= spawnCount; i++)
        {
            spheres.Add(Instantiate(prefab,
                centerRig.position + Vector3.right * spawnRadius,
                Quaternion.identity, centerRig));

            centerRig.Rotate(Vector3.forward, anglePerObject);
        }
    }
}
