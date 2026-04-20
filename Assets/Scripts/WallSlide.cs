using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public float speed;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * speed);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(hit.point, hit.normal);
            Vector3 movement = transform.forward * speed;
            Vector3 slide = movement - Vector3.Dot(movement, hit.normal) * hit.normal;
            slide = Vector3.ProjectOnPlane(movement, hit.normal);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, slide);
        }
    }
}
