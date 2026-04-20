using UnityEditor;
using UnityEngine;

public class DotTest : MonoBehaviour
{
    public Transform target;
    public float dotThreshold = 0.5f;
    public float maxAngle = 45;
    public float range = 20;

    private void OnDrawGizmos()
    {
        Vector3 lookDir = transform.forward;
        Gizmos.DrawRay(transform.position, lookDir * range);
        Collider[] allCubes = Physics.OverlapSphere(transform.position, range);
      
        GameObject bestCube = null;
        float bestDot = -1;
        foreach(Collider cube in allCubes)
        {
            Vector3 directionToCube = (cube.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(lookDir, directionToCube);
            if(dot > dotThreshold && dot > bestDot)
            {
                if(Physics.Raycast(transform.position, directionToCube, out RaycastHit hit) && hit.collider != cube)
                {
                    continue;
                }

                bestCube = cube.gameObject;
                bestDot = dot;
            }
        }
        if(bestCube != null)
        {
            Debug.Log(bestCube.name);
        }

        //Vector3 toTarget = (target.position - transform.position).normalized;
        //float dot = Vector3.Dot(transform.forward, toTarget);
        //bool isInView = dot > Mathf.Cos(Mathf.Deg2Rad * maxAngle);
        //Gizmos.color = isInView? Color.green : Color.red;
        //Gizmos.DrawRay (transform.position, toTarget * 50);
    }
}
