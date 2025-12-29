using System;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Node parent;
    public Vector3 pos;

    // astar algorithm은 결국 f(n) = G(n) + H(n)
    public float nodeTotalCost; // G 시작부터 현재까지의 거리
    public float estimateCost; // H 현재부터 목표지까지 거리 (휴리스틱 추정거리)

    public bool isObstacle;

    public Node(Vector3 pos)
    {
        this.pos = pos;
        parent = null;
        nodeTotalCost = 0;
        estimateCost = 0;
        isObstacle = false;
    }
    
    public void SetObstacle()
    {
        isObstacle = true;
    }

    public float GetFCost()
    {
        return nodeTotalCost + estimateCost;
    }
    
    public int CompareTo(Node other)
    {
        float myF = GetFCost();
        float otherF = other.GetFCost();
        
        if(myF < otherF)
            return -1;
        if(myF > otherF) // 새로운게 더 짧은 더 좋은 경우니까 바꿔줌
            return 1;

        if (estimateCost < other.estimateCost)
            return -1;
        if(estimateCost > other.estimateCost)
            return 1;
        
        return 0;
    }
}
