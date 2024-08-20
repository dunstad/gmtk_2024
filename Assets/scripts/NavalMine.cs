using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavalMine : MonoBehaviour
{
    public GameObject explosionParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            player.Die();
            Instantiate(explosionParticlePrefab, transform.position, transform.rotation);
            AudioSource explosion = gameObject.GetComponent<AudioSource>();
            explosion.Stop();
            explosion.time = .5f;
            explosion.Play();
        }
    }
}
