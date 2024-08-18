using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    private bool move = false;
    private Vector2 moveVec;
    private Rigidbody2D rb;
    public float unpuffedAcceleration;
    public float unpuffedSpeedCap;
    public float puffedAcceleration;
    public float puffedSpeedCap;
    private bool puffed = false;
    public GameObject unpuffedVisuals;
    public GameObject puffedVisuals;
    public Vector2 lastCheckpointPos;
    private CapsuleCollider2D unpuffedCollider;
    private CircleCollider2D puffedCollider;
    public float timeToUnpuff;
    public GameObject puffParticlePrefab;
    public AudioSource puffSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // so we can keep the fish enabled in the editor but prevent control until play is pressed
        gameObject.SetActive(false);
        lastCheckpointPos = rb.position;
        unpuffedCollider = gameObject.GetComponent<CapsuleCollider2D>();
        puffedCollider = gameObject.GetComponent<CircleCollider2D>();
        SetPuffed(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (move)
        {

            float acceleration = puffed ? puffedAcceleration : unpuffedAcceleration;
            float speedCap = puffed ? puffedSpeedCap : unpuffedSpeedCap;
            
            rb.AddForce(moveVec * acceleration, ForceMode2D.Force);

            float clampedVerticalSpeed = Mathf.Clamp(rb.velocity.y, -speedCap, speedCap);
            float clampedHorizontalSpeed = Mathf.Clamp(rb.velocity.x, -speedCap, speedCap);
            rb.velocity = new Vector2(clampedHorizontalSpeed, clampedVerticalSpeed);
        }
    }

    void OnMove(InputValue value)
    {
        move = true;
        Vector2 v = value.Get<Vector2>();
        if (Vector2.zero == v)
        {
            move = false;
        }
        moveVec = v;
    }

    void OnFire(InputValue value)
    {
        Debug.Log("fire");
        SetPuffed(true);
        Invoke("Unpuff", timeToUnpuff);
    }

    void SetPuffed(bool puffed)
    {
        this.puffed = puffed;
        unpuffedVisuals.SetActive(!puffed);
        puffedVisuals.SetActive(puffed);
        unpuffedCollider.enabled = !puffed;
        puffedCollider.enabled = puffed;
        Instantiate(puffParticlePrefab, rb.position, transform.rotation);
        puffSound.time = 0.1f;
        puffSound.Play();
    }

    void Unpuff()
    {
        SetPuffed(false);
    }

    public void Die()
    {
        Debug.Log("X_X");
        rb.position = lastCheckpointPos;
    }
}
