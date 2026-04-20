using UnityEngine;

public class CrossTest : MonoBehaviour
{
    public Transform cube;
    private void OnDrawGizmos()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            Gizmos.DrawLine(transform.position, hit.point);
            Vector3 up = hit.normal;
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, up);
            Vector3 right = Vector3.Cross(up,transform.forward);
            Gizmos.color = Color.red;
            Gizmos.DrawRay (hit.point, right);
            Vector3 forward = Vector3.Cross(right,up);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, forward);
            Quaternion rotation = Quaternion.LookRotation(forward, up);
            Vector3 pos = hit.point + up * 0.75f;
            cube.SetPositionAndRotation(pos, rotation);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 10);
        }
    }
}
