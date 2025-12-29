using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Node[,] nodes;

    private Vector3 origin;
    
    public int rows = 10;
    public int columns = 10;
    public float gridCellSize = 1f;

    private void Awake()
    {
        origin = transform.position;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacles");

        CalculateObstacles();
    }

    private void CalculateObstacles()
    {
        nodes = new Node[rows, columns];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var cellPos = GetGridCellCenter(index);
                Node node = new Node(cellPos);
                nodes[i, j] = node;
                index++;
            }
        }

        if (obstacles.Length > 0) // Grid 위에 장애물 옵젝 있으면 해당 노드를 장애물로 설정
        {
            foreach (var obstacle in obstacles)
            {
                int indexCell = GetGridIndex(obstacle.transform.position);
                if (indexCell == -1)
                    continue;
                
                int row = GetRow(indexCell);
                int col = GetColumn(indexCell);
                nodes[row, col].SetObstacle();                
            }
        }
    }

    private Vector3 GetGridCellCenter(int index)
    {
        var cellPos = GetGridCellPosition(index);
        cellPos.x += gridCellSize/2;
        cellPos.z += gridCellSize/2;
        
        return cellPos;
    }

    private Vector3 GetGridCellPosition(int index)
    {
        int row = GetRow(index);
        int col = GetColumn(index);

        float posX = col * gridCellSize;
        float posZ = row * gridCellSize;
        
        return origin + new Vector3(posX, 0, posZ);
    }

    public int GetGridIndex(Vector3 pos)
    {
        if(!isInBounds(pos))
            return -1;
        
        Vector3 localPos = pos - origin;
        int col = (int)(localPos.x / gridCellSize);
        int row = (int)(localPos.z / gridCellSize);
        
        return row * columns + col;
    }

    public bool isInBounds(Vector3 pos)
    {
        float width = columns * gridCellSize;
        float height = rows * gridCellSize;
        
        return pos.x >= origin.x && pos.x <= origin.x + width && pos.z >= origin.z && pos.z <= origin.z + height;
    }

    public int GetRow(int index)
    {
        return index / columns;   
    }

    public int GetColumn(int index)
    {
        return index % columns;   
    }

    public void GetNeighbors(Node node, List<Node> neighbors)
    {
        int nodeIndex = GetGridIndex(node.pos);
        if (nodeIndex == -1)
            return;
        
        int row =  GetRow(nodeIndex);
        int col =  GetColumn(nodeIndex);
        
        AssignNeighbors(row - 1, col, neighbors);
        AssignNeighbors(row + 1, col, neighbors);
        AssignNeighbors(row, col - 1, neighbors);
        AssignNeighbors(row, col + 1, neighbors);
    }

    public void AssignNeighbors(int row, int col, List<Node> neighbors)
    {
        if (row >= 0 && col >= 0 && row < rows && col < columns)
        {
            Node nodeToAdd =  nodes[row, col];
            
            if(!nodeToAdd.isObstacle)
                neighbors.Add(nodeToAdd);
        }
    }

    public void ResetNodes()
    {
        foreach (Node node in nodes)
        {
            node.nodeTotalCost = 0;
            node.estimateCost = 0;
            node.parent = null;
        }
    }
    
    private void OnDrawGizmos()
    {
        if (rows == 0 || columns == 0 || gridCellSize == 0)
            return;
        
        Gizmos.color = Color.white;
        
        float width = columns * gridCellSize;
        float height = rows * gridCellSize;

        for (int i = 0; i <= rows; i++)
        {
            var startPos = transform.position + i * gridCellSize * Vector3.forward;
            var endPos = startPos + width * gridCellSize * Vector3.right;
            Gizmos.DrawLine(startPos, endPos);
        }

        for (int i = 0; i <= columns; i++)
        {
            var startPos = transform.position + i * gridCellSize * Vector3.right;
            var endPos = startPos + height * gridCellSize * Vector3.forward;
            Gizmos.DrawLine(startPos, endPos);
        }
    }
}
