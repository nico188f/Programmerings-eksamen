using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSystem: MonoBehaviour
{
    public List<Enemy> targetedEnemies;
    public TowerPriority priority;

    void Update()
    {
        BubbleSort(targetedEnemies, priority);

        // Angrib den første fjende på listen, hvis der er nogen
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

    public void BubbleSort(List<Enemy> list, TowerPriority priority)
    {
        int n = list.Count;
        bool swapped;

        do
        {
            swapped = false;

            for (int i = 0; i < n - 1; i++)
            {
                if (priority == TowerPriority.Health)
                {
                    if (list[i].health > list[i + 1].health)
                    {
                        // Swap fjenderne på position i og i + 1
                        Enemy temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;

                        swapped = true;
                    }
                }
                else if (priority == TowerPriority.Speed)
                {
                    if (list[i].speed > list[i + 1].speed)
                    {
                        // Swap fjenderne på position i og i + 1
                        Enemy temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;

                        swapped = true;
                    }
                }
            }
        } while (swapped);
    }
}

public enum TowerPriority
{
    Health,
    Speed
}
