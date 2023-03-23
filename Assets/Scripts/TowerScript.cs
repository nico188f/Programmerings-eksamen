using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public Tower TowerType;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = TowerType.color;
    }
}
