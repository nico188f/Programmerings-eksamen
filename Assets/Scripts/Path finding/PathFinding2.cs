using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding2 : MonoBehaviour
{
    int frame = 0;

    int manhattanDistance = 0;

    public int startingNodeId = 0;
    public int endNodeId = 179;

    public List<TileInfo> CurrentlyDesignatingManhattanDistances = new List<TileInfo>();
    public List<TileInfo> NextWaveOfDesignatingManhattanDistances = new List<TileInfo>();

    public List<TileInfo> OpenSet;

    
    private void Update()
    {
        frame++;
        if (frame == 1)
        {
            CurrentlyDesignatingManhattanDistances.Add(MapGenerator.mapTileInfoScripts[endNodeId]);

            FindManhattanDistances();
        }
        
    }
    public void FindManhattanDistances()
    {
        while (CurrentlyDesignatingManhattanDistances.Count > 0)
        {
            foreach (TileInfo node in CurrentlyDesignatingManhattanDistances)
            {
                node.manhattanDistance = manhattanDistance;
                foreach (int neighborId in node.NeighborIDs)
                {
                    if (MapGenerator.mapTileInfoScripts[neighborId].manhattanDistance == -1 && !NextWaveOfDesignatingManhattanDistances.Contains(MapGenerator.mapTileInfoScripts[neighborId]))
                    {
                        NextWaveOfDesignatingManhattanDistances.Add(MapGenerator.mapTileInfoScripts[neighborId]);
                    }
                }
            }
            manhattanDistance++;
            CurrentlyDesignatingManhattanDistances.Clear();
            foreach (TileInfo node in NextWaveOfDesignatingManhattanDistances)
            {
                Debug.Log(node);
                CurrentlyDesignatingManhattanDistances.Add(node);
            }
            NextWaveOfDesignatingManhattanDistances.Clear();
        }
        pathfinding();
    }
    static public void pathfinding()
    {

    }
}
