using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toSpawn;
    public float spawnCooldownSeconds;
    private float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown = cooldown - Time.deltaTime;
        if (cooldown <= 0)
        {
            Instantiate(toSpawn, transform.position, Quaternion.identity, transform.parent);
            cooldown = spawnCooldownSeconds;
        }
    }
}
