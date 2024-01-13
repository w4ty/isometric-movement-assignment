using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PathGrid : MonoBehaviour
{
    //public Transform StartPosition;
    public LayerMask WallMask;
    private Vector2Int gridWorldSize;
    private Vector3Int gridStart;
    public float NodeRadius;
    public float Distance;

    private Node[,] grid;
    public List<Node> Path;

    private float nodeDiameter;
    private Vector2Int gridSize;
    private Vector3 bottomLeft;

    public void SetGrid(int x, int z)
    {
        Debug.Log("Setting grid");
        gridWorldSize = new Vector2Int(x, z);
        transform.position = new Vector3Int(x/2, 0, z/2);
        nodeDiameter = NodeRadius * 2;
        gridSize = new Vector2Int(Mathf.RoundToInt(gridWorldSize.x / nodeDiameter), Mathf.RoundToInt(gridWorldSize.y / nodeDiameter));
    }

    public void CreateGrid()
    {
        Debug.Log("Creating grid");
        grid = new Node[gridSize.x, gridSize.y];
        bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + NodeRadius) + Vector3.forward * (y * nodeDiameter + NodeRadius);
                bool Wall = true;

                if(Physics.CheckSphere(worldPoint, NodeRadius, WallMask))
                {
                    Wall = false;
                }

                grid[x, y] = new Node(Wall, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 a_WorldPosition)
    {
        float x = (a_WorldPosition.x - bottomLeft.x) / nodeDiameter;
        float y = (a_WorldPosition.z - bottomLeft.z) / nodeDiameter;

        int ix = Mathf.RoundToInt(x);
        int iy = Mathf.RoundToInt(y);

        return grid[ix, iy];

    }

    public List<Node> GetNeighborNodes(Node a_Node)
    {
        List<Node> NeighboringNodes = new List<Node>();
        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y<= 1; y++)
            {
                if(x == 0 && y == 0)
                {
                    continue;
                }

                int checkX = a_Node.GridX + x;
                int checkY = a_Node.GridY + y;

                if(checkX >= 0 && checkX < gridSize.x && checkY >= 0 && checkY < gridSize.y)
                {
                    NeighboringNodes.Add(grid[checkX, checkY]);
                }
            }
        }
        return NeighboringNodes;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                if (n.IsWall)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                if (Path != null)
                {
                    if (Path.Contains(n))
                    {
                        Gizmos.color = Color.red;
                    }
                }

                Gizmos.DrawCube(n.Position, Vector3.one * (nodeDiameter - Distance));
            }
        }
    }
}
