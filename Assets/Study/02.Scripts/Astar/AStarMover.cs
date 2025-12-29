using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarMover : MonoBehaviour
{
    public GridManager gridManager;
    private AStar aStarCalculator;

    public GameObject startCube, endCube;
    public List<Node> pathList = new List<Node>();

    private void Awake()
    {
        aStarCalculator = new AStar();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            GetPath();
            yield return new WaitForSeconds(1f);
        }
    }

    private void GetPath()
    {
        int startIndex = gridManager.GetGridIndex(startCube.transform.position);
        int endIndex = gridManager.GetGridIndex(endCube.transform.position);

        if (startIndex == -1 || endIndex == -1)
            return;
        
        Node startNode = gridManager.nodes[gridManager.GetRow(startIndex), gridManager.GetColumn(startIndex)];
        Node endNode = gridManager.nodes[gridManager.GetRow(endIndex), gridManager.GetColumn(endIndex)];
        
        pathList = aStarCalculator.FindPath(startNode, endNode, gridManager);
    }

    void OnDrawGizmos()
    {
        if (pathList == null || pathList.Count < 2)
            return;
        
        Gizmos.color = Color.green;
        for (int i = 0; i < pathList.Count-1; i++)
            Gizmos.DrawLine(pathList[i].pos, pathList[i+1].pos);
    }

}
