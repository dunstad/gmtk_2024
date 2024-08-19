using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    public float speed;
    public float lifetime;
    float spawnTime;
    public GameObject explosionParticlePrefab;
    Rigidbody2D target;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        var search = FindObjectsByType<CharacterController2D>(FindObjectsSortMode.None);
        if (search.Length > 0)
        {
            target = search[0].GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            var search = FindObjectsByType<CharacterController2D>(FindObjectsSortMode.None);
            if (search.Length > 0)
            {
                target = search[0].GetComponent<Rigidbody2D>();
            }
        }
    }

    void FixedUpdate()
    {
        if (Time.time - spawnTime > lifetime)
        {
            Die();
        }

        if (target)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            Vector2 moveVec = (target.position - pos);
            moveVec.Normalize();
            transform.eulerAngles = (new Vector3(0, 0, Vector2.Angle(Vector2.up, moveVec) * (moveVec.x < 0 ? 1 : -1)));

            // should probably be using a rigidbody but oh well
            // would be nice to have the interpolation though
            transform.position = Vector2.MoveTowards(pos, moveVec + pos, .1f * speed);
        }
    }

    void Die()
    {
        Instantiate(explosionParticlePrefab, transform.position, transform.rotation);
        AudioSource explosionSound = GameObject.FindWithTag("explosionSound").GetComponent<AudioSource>();
        explosionSound.transform.position = transform.position;
        explosionSound.Stop();
        explosionSound.time = .5f;
        explosionSound.Play();
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
    //     if (player)
    //     {
    //         player.Die();
    //         Die();
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            player.Die();
        }
        Die();
    }
}
