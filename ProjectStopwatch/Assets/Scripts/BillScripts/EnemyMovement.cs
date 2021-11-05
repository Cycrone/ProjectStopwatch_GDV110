using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRigidBody2D;

    //Enemy movement declarations
    #region Enemy Movement Declarations
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float moveDistance = 5f;

    
    private float startPos;
    private float endPos;

    public bool facingRight;
    public bool movingRight;
    #endregion

    //Enemy shootingn declarations
    #region Enemy Shooting declarations
    [SerializeField]
    GameObject enemyBullet;

    float fireRate;
    float nextFire;

    #endregion

    public enemyState States;

    public enum enemyState
    {
        Patrolling,
        Shooting
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = transform.localScale.x > 0;
        //transform.Rotate = new Vector3(0, 180, 0);
    }

    void TimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + moveDistance;
        facingRight = transform.localScale.x > 0;

    }

    public void Start()
    {
        States = enemyState.Patrolling;
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    public void Update()
    {

        switch (States)
        {
            //Enemy ai state Patrolling ----------------------
            case enemyState.Patrolling:
                
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


                break;

            //Enemy ai state Shooting----------------------
            case enemyState.Shooting:
                TimeToFire();

                
                break;


            default:
                break;
        }

    }

}
