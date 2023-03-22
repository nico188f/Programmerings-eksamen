using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TowerPlacementButton : MonoBehaviour
{
    public Tower Tower;
    
    [Header("Ui Objects")]
    public GameObject NameTextUi;
    public GameObject ImageUi;
    public void TowerSelected()
    {
        TowerPlacementUiManager.SelectedTower = Tower;
    }

    private void Start()
    {
        NameTextUi.GetComponent<TMP_Text>().text = Tower.name;
        ImageUi.GetComponent<Image>().color = Tower.color;
    }

}
