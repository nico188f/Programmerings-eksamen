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
    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(map.mapWidth/ nodeRadius);
        gridSizeY = Mathf.RoundToInt(map.mapHight / nodeRadius);
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
                grid[x, y] = new Node(walkable, worldPos, x,y); 
            }
        }
    }

    public void CheckGrid()
    {
        for (int x = 0; x < map.mapWidth; x++)
        {
            for (int y = 0; y < map.mapHight; y++)
            {
                Vector3 worldPos = new Vector3(x, y, 0);
                bool _walkable = !(Physics2D.OverlapCircle(new Vector2(x, y), 0.5f, unwalkableMask));
                Node n = NodeFromWorldPoint(worldPos);
                n.walkable = _walkable;
            }
        }
    }
    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        for (int x=-1; x<=1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >=0 && checkY <gridSizeY)
                {
                    neighbors.Add(grid[checkX, checkY]);
                    
                }
            }

        }
        return neighbors;
    }
    public Node NodeFromWorldPoint(Vector3 Worldposition)
    {

        int x = Mathf.RoundToInt(Worldposition.x);
        int y = Mathf.RoundToInt(Worldposition.y);

        return grid[x, y];


    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }
    public List<Node> path;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(map.mapWidth, map.mapHight, 0));

        if (grid != null)
        {
            foreach(Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                if(path != null)
                {
                    if (path.Contains(n))
                        Gizmos.color = Color.black;
                }

                Gizmos.DrawCube(n.worldPosition, new Vector3(0.5f, 0.5f, 0.5f));
            }
        }
            
    }
}



