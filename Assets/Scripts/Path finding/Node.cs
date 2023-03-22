using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPos;

    public Node(bool iswalkable, Vector3 _worldPos)
    {
        walkable = iswalkable;
        worldPos = _worldPos;
    }
}
