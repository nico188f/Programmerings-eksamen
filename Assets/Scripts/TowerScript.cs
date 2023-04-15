using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

//kilde: https://www.youtube.com/watch?v=2zVwug_agr0
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

    public TileInfo ParentTileScript;

    public GameObject TargetEnemy;

    public GameObject Projectile;

    private void OnMouseUp()
    {
        ParentTileScript.DestroyTowerOnTile();
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = TowerType.color;
        TargetEnemy = GameObject.Find("Enemy (1)");
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
        if (timeSinceLastShoot > TowerType.secondsBetweenShoots) // && EnemysInRange.Count > 0
        {
            timeSinceLastShoot -= TowerType.secondsBetweenShoots;
            Fire(TargetEnemy);
        }
    }

    public void Fire(GameObject Enemy)
    {
        GameObject ProjectileInstance = Instantiate(Projectile, new Vector3(transform.position.x,transform.position.y ,-1), Quaternion.identity);
        InterceptionDirection(TargetEnemy.transform.position, transform.position, TargetEnemy.GetComponent<Rigidbody2D>().velocity, TowerType.projectile.speed, out Vector2 direction);
        
        ProjectileInstance.GetComponent<Rigidbody2D>().velocity = direction * TowerType.projectile.speed;
    }

    public void TryToAim(Vector2 PointA, Vector2 PointB, GameObject Enemy)
    {
        
    }

    public bool InterceptionDirection(Vector2 A, Vector2 B, Vector2 VA, float sB, out Vector2 result)
    {
        Vector2 AToB = B - A;
        float lC = AToB.magnitude;
        float alpha = Vector2.Angle(AToB, VA) * Mathf.Rad2Deg;
        float sA = VA.magnitude;
        float r = sA / sB;
        if (SolveQuadratic(1 - r * r, 2 * r * lC * Mathf.Cos(alpha), -(lC * lC), out float root1, out float root2) == 0)
        {
            result = Vector2.zero;
            Debug.Log(false);
            return false;
        }
        float lA = Mathf.Max(root1, root2);
        float t = lA / sB;
        Vector2 C = A + VA * t;
        result = (C - B).normalized;
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
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }
}
