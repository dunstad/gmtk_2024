using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    private bool move = false;
    private Vector2 moveVec;
    private Rigidbody2D rb;
    public float acceleration;
    public float speedCap;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // so we can keep the fish enabled in the editor but prevent control until play is pressed
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (move)
        {
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
    }
}
