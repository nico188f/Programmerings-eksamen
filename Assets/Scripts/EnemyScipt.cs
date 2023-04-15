using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScipt : MonoBehaviour
{
    public Enemy Enemy;

    public Vector2 Movement;

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = (Movement);
    }
}
