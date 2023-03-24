using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TileInfo : MonoBehaviour
{
    
    public int tileID;
    public List<int> NeighborIDs = new List<int>();
    public List<int> WalkebleNeighborIDs = new List<int>();

    public GameObject TowerPrefab;
    public GameObject TowerPreviewPrefab;

    GameObject TowerPreviewGameObject;
    GameObject TowerGameObject;

    bool tileHasTower = false;

    public void EnebleNode()
    {
        foreach (int neighborID in NeighborIDs)
        {
            MapGenerator.mapTiles[neighborID].GetComponent<TileInfo>().WalkebleNeighborIDs.Add(tileID);
        }
    }

    public void DisableNode()
    {
        foreach (int neighborID in NeighborIDs)
        {
            MapGenerator.mapTiles[neighborID].GetComponent<TileInfo>().WalkebleNeighborIDs.Remove(tileID);
        }
    }

    private void OnMouseEnter()
    {
        if (TowerPlacementUiManager.SelectedTower != null && !tileHasTower)
        {
            Color TowerColor = TowerPlacementUiManager.SelectedTower.color;
            TowerPreviewGameObject = Instantiate(TowerPreviewPrefab, transform);
            TowerPreviewGameObject.GetComponent<Transform>().localPosition = new Vector2(0, 0); 
            TowerPreviewGameObject.GetComponent<SpriteRenderer>().color = new Color(TowerColor.r, TowerColor.g, TowerColor.b, 0.5f);
        }
    }

    private void OnMouseExit()
    {
        if (TowerPlacementUiManager.SelectedTower != null && !tileHasTower)
        {
            Destroy(TowerPreviewGameObject);
        }
    }

    private void OnMouseUp()
    {
        if (TowerPlacementUiManager.SelectedTower != null && !tileHasTower)
        {
            TowerGameObject = Instantiate(TowerPrefab, transform);
            TowerGameObject.GetComponent<TowerScript>().TowerType = TowerPlacementUiManager.SelectedTower;
            TowerGameObject.GetComponent<Transform>().localPosition = new Vector2(0, 0);
            tileHasTower = true;
            Destroy(TowerPreviewGameObject);
            DisableNode();
        }
        else if (TowerPlacementUiManager.SelectedTower == null &&  tileHasTower)
        {
            Destroy(TowerGameObject);
            tileHasTower = false;
            EnebleNode();
        }
        GameObject.Find("AStarGrid").GetComponent<AStarGrid>().CheckGrid();
    }

}
