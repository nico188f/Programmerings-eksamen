using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Scriptable Object/Create New Tower")]
public class Tower : ScriptableObject
{
    public Color color;
    public float range;
    public float secondsBetweenShoots;
    public Projectile projectile;
}

