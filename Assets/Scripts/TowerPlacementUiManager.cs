using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TowerPlacementUiManager : MonoBehaviour
{
    [SerializeField] static public Tower SelectedTower;
    public List<Tower> Towers = new List<Tower>();
    public GameObject TowerBtn;

    private void Start()
    {
        GenerateTowerUiButtons();
    }
    public void GenerateTowerUiButtons()
    {
        foreach (Tower tower in Towers)
        {
            GameObject temp = Instantiate(TowerBtn, transform);
            temp.GetComponent<TowerPlacementButton>().Tower = tower;
        }
    }

    
}
