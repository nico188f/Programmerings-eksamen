using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject MapTile;

    public int mapWidth;
    public int mapHight;

    static public List<GameObject> mapTiles = new List<GameObject>();
    static public List<TileInfo> mapTileInfoScripts = new List<TileInfo>();
    private List<GameObject> pathTiles = new List<GameObject>();

    private void Start()
    {
        generateMap();
    }

    private List<GameObject> getTopEdgeTiles()
    {
        List<GameObject> edgeTiles =new List<GameObject>();

        for (int i = mapWidth * (mapHight-1); i < mapWidth * mapHight; i++)
        {
            edgeTiles.Add(mapTiles[i]);
        }

        return edgeTiles;
    }

    private List<GameObject> getBottomEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();

        return edgeTiles;
    }

    private void generateMap()
    {
        for(int y = 0; y < mapHight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                int tileID = y * mapWidth + x;
                GameObject newTile = Instantiate(MapTile);

                mapTiles.Add(newTile);
                mapTileInfoScripts.Add(newTile.GetComponent<TileInfo>());

                FindNeighbors(tileID);

                newTile.transform.position = new Vector2(x, y);
            }
        } 

        List<GameObject> topEdgeTiles = getTopEdgeTiles();
    }

    private void FindNeighbors(int tileId)
    {
        //checks if the tile is on the buttom edge
        if (tileId >= mapWidth)
        {
            //adds tile below
            mapTileInfoScripts[tileId].NeighborIDs.Add(tileId - mapWidth);
            mapTileInfoScripts[tileId].WalkebleNeighborIDs.Add(tileId - mapWidth);
        }
        //checks if the tile is on the top edge
        if (tileId < mapWidth * (mapHight - 1))
        {
            //adds tile above
            mapTileInfoScripts[tileId].NeighborIDs.Add(tileId + mapWidth);
            mapTileInfoScripts[tileId].WalkebleNeighborIDs.Add(tileId + mapWidth);
        }
        //checks if the tile is on the left edge
        if (!(tileId % mapWidth == 0))
        {
            //adds tile to the right
            mapTileInfoScripts[tileId].NeighborIDs.Add(tileId - 1);
            mapTileInfoScripts[tileId].WalkebleNeighborIDs.Add(tileId - 1);
        }
        //checks if the tile is on the right edge
        if (!((tileId + 1) % mapWidth == 0))
        {
            //adds tile to the left
            mapTileInfoScripts[tileId].NeighborIDs.Add(tileId + 1);
            mapTileInfoScripts[tileId].WalkebleNeighborIDs.Add(tileId + 1);
        }
    }

}
