using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{
    public GameObject puffParticlePrefab;
    public GameObject deathParticlePrefab;
    IEnumerator animate;
    float startY;
    Vector2 startPos;
    bool move = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        animate = Animate();
        StartCoroutine(animate);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (move)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector3.up + transform.position, .1f * speed);
        }
    }

    IEnumerator Animate()
    {
        while (!move) {
            transform.position = new Vector2(transform.position.x, startY + Mathf.Sin(Time.time) / 8 );
            yield return null;
        }
    }

    public void Die()
    {
        AudioSource hissSound = GameObject.FindWithTag("hissSound").GetComponent<AudioSource>();
        hissSound.Stop();
        hissSound.time = .2f;
        hissSound.Play();
        Instantiate(puffParticlePrefab, transform.position, transform.rotation);
        Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        transform.position = startPos;
        move = false;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            if (player.puffed)
            {
                Die();
            } else
            {
                player.Die();
            }
        }
        transform.position = startPos;
        move = false;
        AudioSource moveSound = gameObject.GetComponent<AudioSource>();
        moveSound.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            move = true;
            AudioSource moveSound = gameObject.GetComponent<AudioSource>();
            moveSound.time = .5f;
            moveSound.Play();
        }
    }
}
