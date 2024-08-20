using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiddo : MonoBehaviour
{
    IEnumerator animate;
    float startY;
    AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        startY = transform.position.y;
        animate = Animate();
        StartCoroutine(animate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Animate()
    {
        while (true) {
            transform.position = new Vector2(transform.position.x, startY + Mathf.Sin(Time.time + transform.position.x) / 8 );
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            
            AudioSource sound = sounds[Random.Range(0, sounds.Length - 1)];
            sound.Play();
        }
    }
}
