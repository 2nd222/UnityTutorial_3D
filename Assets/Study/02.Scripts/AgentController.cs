using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AgentController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    
    public Transform[] points;
    public int index;
    
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private NavMeshSurface surface;
    public float bakeDistance = 10f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        surface.transform.position = transform.position;
        surface.BuildNavMesh();
        //SetRandomPoint();
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
                agent.SetDestination(hit.point);
        }
        
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        // var dir = new Vector3(h, 0, v);
        // dir = dir.normalized;
        // agent.SetDestination(transform.position + dir);
        
        float distance = Vector3.Distance(transform.position, surface.transform.position);
        if (distance > bakeDistance)
        {
            surface.transform.position = transform.position;
            surface.BuildNavMesh();
        }
    }
    
    // void Update()
    // {
    //     if (agent.remainingDistance <= 1.5f)
    //     {
    //         Debug.Log("목적지 변경");
    //         SetRandomPoint();
    //     }
    // }

    private void SetRandomPoint()
    {
        int temp = index;
        while (temp == index)
            index = Random.Range(0, points.Length);
        
        agent.SetDestination(points[index].position);
    }
}
