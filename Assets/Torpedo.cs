using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    public GameObject explosionParticlePrefab;
    Rigidbody2D target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectsByType<CharacterController2D>(FindObjectsSortMode.None)[0].GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 moveVec = (target.position - new Vector2(transform.position.x, transform.position.y));
        moveVec.Normalize();
        transform.eulerAngles = (new Vector3(0, 0, Vector2.Angle(Vector2.up, moveVec) * (moveVec.x < 0 ? 1 : -1)));
    }

    void Die()
    {
        Instantiate(explosionParticlePrefab, transform.position, transform.rotation);
        AudioSource explosion = gameObject.GetComponent<AudioSource>();
        explosion.Stop();
        explosion.time = .5f;
        explosion.Play();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            player.Die();
            Die();
        }
    }
}
