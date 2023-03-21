using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapTile;

    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHight;

    private void generateMap()
    {
        for(int y = 0; y < mapHight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                GameObject newTile = Instantiate(mapTile);

                newTile.transform.position = new Vector2(x, y);
            }
        }
    }
}
