using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public Tower TowerType;

    public float timeSinceLastShoot;
    public List<GameObject> EnemysInRange = new List<GameObject>();

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = TowerType.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemysInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemysInRange.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        timeSinceLastShoot += Time.deltaTime;
        if (timeSinceLastShoot > TowerType.secondsBetweenShoots && EnemysInRange.Count > 0)
        {
            //ShootEnemy(TargetEnemy)
        }
    }

    public void ShootEnemy(GameObject Enemy)
    {
        
    }

    /*public Vector2 TryToAim(Vector2 PointA, Vector2 PointB, GameObject Enemy)
    {
        float test = 
    }*/

    

}
