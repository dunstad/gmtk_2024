using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Checkpoint : MonoBehaviour
{
    public Light2D light;
    private float startingIntensity;
    // Start is called before the first frame update
    void Start()
    {
        startingIntensity = light.intensity;
        light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (light.intensity == 0)
        {
            CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
            if (player)
            {
                AudioSource sound = GetComponent<AudioSource>();
                sound.time = .15f;
                sound.Play();
                player.lastCheckpointPos = new Vector2(transform.position.x, transform.position.y);
                light.intensity = startingIntensity;
            }
        }
    }
}
