using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementandAnimation : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    private bool facingRight;
    private Vector3 Flipper;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Flipper = new Vector3(0, 180, 0);
        
        facingRight = true;
    }

    
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", movement.x);

        // Flipping the character
        if (movement.x < 0 && facingRight || movement.x > 0 && !facingRight)
        {
            transform.Rotate(Flipper);
            facingRight = !facingRight;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * moveSpeed);
    }
}
