using UnityEngine;

public class Tigonemotry : MonoBehaviour
{
    public int pointCount = 4;
    public float radius = 1;
    public float angle = 45;
    private void OnDrawGizmos()
    {
        
        float angleRad = Mathf.Deg2Rad * angle;
        float x = Mathf.Cos(angleRad) * radius;
        float y = Mathf.Sin(angleRad) * radius;
        Vector3 direction = new Vector3(x, y, 0);
        Gizmos.DrawRay(transform.position, direction * radius);
        //return;
        //for (int i = 0; i < pointCount; i++)
        //{
        //    float angle = (Mathf.PI * 2 / pointCount) * i;
        //    float x = Mathf.Cos(angle) * radius;
        //    float y = Mathf.Sin(angle) *radius;
        //    Gizmos.DrawSphere(new Vector3(x, y, 0), 0.1f);
        //}
       
    }
}
