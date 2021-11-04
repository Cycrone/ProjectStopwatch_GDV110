using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private int moveDistance = 5;

    private Rigidbody2D enemyRigidBody2D;
    private float startPos;
    private float endPos;

    public bool facingRight;
    public bool movingRight;


    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + moveDistance;
        facingRight = transform.localScale.x > 0;
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = transform.localScale.x > 0;
        //transform.Rotate = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    public void Update()
    {
        if (movingRight)
        {
            enemyRigidBody2D.AddForce(Vector2.right * moveSpeed * Time.deltaTime);
            if (!facingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= endPos)
            movingRight = false;

        if (!movingRight)
        {
            enemyRigidBody2D.AddForce(-Vector2.right * moveSpeed * Time.deltaTime);
            if (facingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= startPos)
            movingRight = true;
    }

}
