using UnityEngine;
using UnityEngine.Jobs;

public struct MoveBulletsJob : IJobParallelForTransform
{
    public float speed;
    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        Vector3 forward = transform.rotation * Vector3.forward;
        transform.position += speed * deltaTime * forward;
    }
}
