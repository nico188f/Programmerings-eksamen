using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

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
            //Fire(TargetEnemy)
        }
    }

    public void Fire(GameObject Enemy)
    {
        
    }

    public void TryToAim(Vector2 PointA, Vector2 PointB, GameObject Enemy)
    {
        
    }

    public bool InterceptionDirection(GameObject Enemy, out Vector2 Result)
    {
        Vector2 TowerToEnemy = GetComponent<Transform>().position - Enemy.GetComponent<Transform>().position;
        float distanceBetweenTowerAndEnemy = TowerToEnemy.magnitude;

        float angleBetweenTowerEnemyAndEnemyDestination = Vector2.Angle(TowerToEnemy, Enemy.GetComponent<Rigidbody2D>().velocity) * Mathf.Deg2Rad;
        float ratio = Enemy.GetComponent<EnemyScipt>().Enemy.speed / TowerType.projectile.speed;

        if (SolveQuadratic(1 - ratio * ratio, 2 * ratio * distanceBetweenTowerAndEnemy * Mathf.Cos(angleBetweenTowerEnemyAndEnemyDestination),
            0 - (Mathf.Pow(distanceBetweenTowerAndEnemy, 2)), out float root1, out float root2) == 0)
        {
            Result = Vector2.zero;
            return false;
        }
        float DistancebetweenInterceptionPointAndTower = Mathf.Max(root1, root2);
        float Time = DistancebetweenInterceptionPointAndTower / TowerType.projectile.speed;
        Vector2 InterceptionPoint = Enemy.GetComponent<Transform>().position * Enemy.GetComponent<Rigidbody2D>().velocity * Time;
        Result = (InterceptionPoint - new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y)).normalized;
        return true;
    }

    private int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        float discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }
        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (+b + Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }
}
