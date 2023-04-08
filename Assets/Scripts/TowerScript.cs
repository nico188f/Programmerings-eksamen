using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public enum Direction
    {
        Forward,
        Backward,
        Up,
        Down,
    }
    public Direction direction;

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

    public void TryToAim(Vector2 PointA, Vector2 PointB, GameObject Enemy)
    {
        switch (direction)
        {
            case Direction.Forward:
                break;
            case Direction.Backward:
                break;
            case Direction.Up:
                break;
            case Direction.Down:
                break;
            default:
                break;
        }
    }
}
