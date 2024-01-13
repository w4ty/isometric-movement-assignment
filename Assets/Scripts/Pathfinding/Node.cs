using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int GridX;
    public int GridY;

    public bool IsWall;
    public Vector3 Position;

    public Node Parent;

    public int GCost;
    public int HCost;

    public int FCost {  get {  return GCost + HCost; } }

    public Node(bool a_isWall, Vector3 a_Pos, int a_GridX, int a_GridY)
    {
        IsWall = a_isWall;
        Position = a_Pos;
        GridX = a_GridX;
        GridY = a_GridY;
    }
}
