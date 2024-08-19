using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFish : MonoBehaviour
{
    public GameObject puffParticlePrefab;
    public GameObject deathParticlePrefab;
    IEnumerator animate;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
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

    public void Die()
    {
        Instantiate(puffParticlePrefab, transform.position, transform.rotation);
        Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player && player.puffed)
        {
            Die();
        }
    }
}
