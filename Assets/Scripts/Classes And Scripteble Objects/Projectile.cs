using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Scriptable Object/Create New Projectile")]
public class Projectile : ScriptableObject
{
    public float speed;
    public float damage;
    public float areaOfEffect;
}
