using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int tileID;
    public List<int> NeighborIDs = new List<int>();
    public List<int> WalkebleNeighborIDs = new List<int>();

    public void EnebleNode()
    {
        foreach (int neighborID in NeighborIDs)
        {
            MapGenerator.mapTiles[neighborID].GetComponent<TileInfo>().WalkebleNeighborIDs.Add(tileID);
        }
    }



}
