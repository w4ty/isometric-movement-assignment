using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    [SerializeField]
    private PathGrid envGrid;

    public void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        envGrid.CreateGrid();
        Node StartNode = envGrid.NodeFromWorldPosition(a_StartPos);
        Node TargetNode = envGrid.NodeFromWorldPosition(a_TargetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartNode);

        while(OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
            for(int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].HCost < CurrentNode.HCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
                break;
            }

            foreach (Node NeighborNode in envGrid.GetNeighborNodes(CurrentNode))
            {
                if(!NeighborNode.IsWall || ClosedList.Contains(NeighborNode))
                {
                    continue;
                }
                int MoveCost = CurrentNode.GCost + GetManhattanDistance(CurrentNode, NeighborNode);

                if (MoveCost < NeighborNode.FCost || !OpenList.Contains(NeighborNode))
                {
                    NeighborNode.GCost = MoveCost;
                    NeighborNode.HCost = GetManhattanDistance(NeighborNode, TargetNode);
                    NeighborNode.Parent = CurrentNode;

                    if (!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }
        }
    }

    private void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;

        while(CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }

        FinalPath.Reverse();

        envGrid.Path = FinalPath;
    }

    int GetManhattanDistance(Node a_NodeA, Node a_NodeB)
    {
        int ix = Mathf.Abs(a_NodeA.GridX - a_NodeB.GridX);
        int iy = Mathf.Abs(a_NodeA.GridY - a_NodeB.GridY);

        return ix + iy; 
    }
}
