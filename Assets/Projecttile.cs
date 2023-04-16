using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    float despawnTime = 5;
    float timeSinceInstanciated = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (timeSinceInstanciated > despawnTime)
        {
            Destroy(gameObject);
        }
        timeSinceInstanciated += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
