using System;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{    
    private float HorizontalInput;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
        RigidbodyPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.IsAlive())
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.125f);

            Debug.DrawRay(transform.position, Vector3.down * 0.125f, Color.red);

            animator.SetBool("running", HorizontalInput != 0.0f && Grounded);
            animator.SetBool("jumping", !Grounded);

            if (HorizontalInput < 0) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            else if (HorizontalInput > 0) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);



            if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        RigidbodyPlayer.AddForce(Vector2.up * player.JumpForce);
    }

    private void FixedUpdate()
    {
        RigidbodyPlayer.velocity = new Vector2(HorizontalInput * player.Speed, RigidbodyPlayer.velocity.y);
    }
}
