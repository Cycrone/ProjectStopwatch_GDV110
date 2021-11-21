using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Animator animator;
   

    public bool facingRight;
    private float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] public int health = 1;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] public GameObject DeathScreenUI;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        DeathScreenUI.SetActive(true);
    }

    private void Update()
    {
        //IsGrounded();
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        rb.velocity = new Vector2(dirX, rb.velocity.y);

        if (IsGrounded() == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            animator.SetBool("isJumping", false);
            animator.SetFloat("speed", Mathf.Abs(dirX));
        }


        if (IsGrounded() == false)
        {
            animator.SetBool("isJumping", true);
        }
            FlipPlayer();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }

  

    void FlipPlayer()
    {
        if ((dirX < 0 && facingRight) || (dirX > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }


}