    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Object/Create New Enemy")]
public class Enemy : ScriptableObject
{
    public float speed;
    public float health;
}
