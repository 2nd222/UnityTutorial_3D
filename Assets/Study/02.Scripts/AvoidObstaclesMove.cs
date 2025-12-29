using System;
using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f;

    private Vector3 targetPoint;
    public float steeringForce = 10f;
    
    public LayerMask obstacleMask;

    private void Start()
    {
        targetPoint = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
                targetPoint = hit.point;
        }
        Vector3 dir =  (targetPoint - transform.position).normalized;
        dir.y = 0;
        dir = GetAvoidanceDirection(dir);

        if (Vector3.Distance(transform.position, targetPoint) < 1f)
            return;
        
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        Quaternion rot =  Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);
    }

    private Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, obstacleMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0;
            
            dir = transform.forward + hitNormal * force;
            dir.Normalize();
            dir.y = 0;
        }
        return dir;
    }
}
