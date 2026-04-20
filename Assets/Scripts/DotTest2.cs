using UnityEngine;

public class DotTest2 : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Transform target;
    public float startVelocity;

    void Start()
    {
        Vector3 toTarget = target.position - transform.position;
        rigidbody.linearVelocity = toTarget.normalized * startVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.GetContact(0).normal;

        Debug.Log("Collsion dot " + Vector3.Dot(collision.relativeVelocity, normal));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,target.position);
    }
}
