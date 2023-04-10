using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSystem : MonoBehaviour
{
    public List<Enemy> targetedEnemies;
    public TowerPriority priority;

    void Update()
    {
        // Sorter fjender baseret på prioritet
        if (priority == TowerPriority.Health)
        {
            targetedEnemies.Sort((a, b) => a.health.CompareTo(b.health));
        }
        else if (priority == TowerPriority.Speed)
        {
            targetedEnemies.Sort((a, b) => a.speed.CompareTo(b.speed));
        }

        // Angrib den første fjende på listen hvis der er nogen
        if (targetedEnemies.Count > 0)
        {
            Attack(targetedEnemies[0]);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            targetedEnemies.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            targetedEnemies.Remove(enemy);
        }
    }

    void Attack(Enemy enemy)
    {
        // Angrib fjenden
    }
}

public enum TowerPriority
{
    Health,
    Speed
}
