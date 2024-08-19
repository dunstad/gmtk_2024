using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toSpawn;
    public float spawnCooldownSeconds;
    private float cooldown = 0;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AudioSource spawnSound = GetComponent<AudioSource>();
        cooldown = cooldown - Time.deltaTime;
        if ((cooldown <= 0) && active)
        {
            Instantiate(toSpawn, transform.position, Quaternion.identity, transform.parent);
            cooldown = spawnCooldownSeconds;
            spawnSound.Stop();
            spawnSound.time = .6f;
            spawnSound.Play();

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            active = false;
        }
    }
}
