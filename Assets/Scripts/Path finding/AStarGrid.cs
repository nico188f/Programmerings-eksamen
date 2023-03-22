using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarGrid : MonoBehaviour
{
    int gridSizeX, gridSizeY;
    float nodeDiameter;
    public MapGenerator map;
    public LayerMask unwalkableMask;

    public Transform[] enemies;

    float nodeRadius = 1;
    Node[,] grid;
    void Start()

    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(map.mapWidth / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(map.mapHight / nodeDiameter);
        CreateGrid();

    }
    void CreateGrid()
    {
        grid = new Node[map.mapWidth, map.mapHight];

        for (int x = 0; x < map.mapWidth; x++)
        {
            for (int y = 0; y < map.mapHight; y++)
            {
                Vector3 worldPos = new Vector3(x, y, 0);
                bool walkable = !(Physics2D.OverlapCircle(new Vector2(x, y), 0.5f, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPos);
            }
        }
    }
    public Node NodeFromWorldPoint(Vector3 Worldposition)
    {

        int x = Mathf.RoundToInt(Worldposition.x);
        int y = Mathf.RoundToInt(Worldposition.y);

        return grid[x, y];


    }

    private void OnDrawGizmos()
    {
        if (grid == null)
            return;

        Gizmos.DrawWireCube(transform.position, new Vector3(map.mapWidth, map.mapHight, 0));
        Node enemy1 = NodeFromWorldPoint(enemies[0].position);
        Node enemy2 = NodeFromWorldPoint(enemies[1].position);
        foreach (Node n in grid)
        {
            Gizmos.color = (n.walkable) ? Color.white : Color.red;
            if (enemy1 == n || enemy2 == n)
            {
                Gizmos.color = Color.cyan;
            }
            Gizmos.DrawCube(n.worldPos, Vector3.one);
        }
    }
}



