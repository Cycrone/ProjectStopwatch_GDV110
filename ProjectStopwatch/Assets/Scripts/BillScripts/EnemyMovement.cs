using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRigidBody2D;
    GameObject EnemyGun;
    [SerializeField]GameObject PlayerGO;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] public float aTimer = 100;
    public int health = 100;
    float angleBetween = 2f;
    float angleUp = 5f;
    float angleDown = 1f;

    [SerializeField] Transform Player;
    [SerializeField] Transform castPoint;       //The point at where the enemy sight of view will be from

    private float startPos;
    private float endPos;
    private float endPosBetween;
    private float endPosTop;
    private float endPosDown;

    public bool facingRight;
    public bool movingRight;

    float timer = 0;
    bool timerReached = false;

    

    #region Bullet
    [SerializeField]
    GameObject enemyBullet;

    float fireRate;
    float nextFire;
    #endregion

    IEnumerator timeWait()
{
    yield return new WaitForSeconds(5);

}

    void TimeToFire()
    {
        StartCoroutine(timeWait());
        if (Time.time > nextFire)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerGO.GetComponent<HUD>().timer += aTimer;   
            Die();
            
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = transform.localScale.x > 0;
        //transform.Rotate = new Vector3(0, 180, 0);
    }

    bool CanSeePlayer(float distance)   //Parameter is distance the enemy can see
    {
        bool val = false;   //temp local variable
        float castDist = distance;

        if (!facingRight)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;     //equivalence of saying new vector3/2 (posx + distance)
        Vector2 endPosBetween = castPoint.position + Vector3.right * castDist + Vector3.up * angleBetween;
        Vector2 endPosTop = castPoint.position + Vector3.right * castDist + Vector3.up * angleUp;
        Vector2 endPosDown = castPoint.position + Vector3.right * castDist + Vector3.down * angleDown;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Shootable"));      //*(start, end, what it look for) (LAYER Shootable----!!!!!!)
        RaycastHit2D hit2 = Physics2D.Linecast(castPoint.position, endPosBetween, 1 << LayerMask.NameToLayer("Shootable"));
        RaycastHit2D hit3 = Physics2D.Linecast(castPoint.position, endPosTop, 1 << LayerMask.NameToLayer("Shootable"));
        RaycastHit2D hit4 = Physics2D.Linecast(castPoint.position, endPosDown, 1 << LayerMask.NameToLayer("Shootable"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        else if (hit2.collider != null)
        {
            if (hit2.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        else if (hit3.collider != null)
        {
            if (hit3.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        else if (hit4.collider != null)
        {
            if (hit4.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        Debug.DrawLine(castPoint.position, endPos, Color.red);
        Debug.DrawLine(castPoint.position, endPosBetween, Color.green);
        Debug.DrawLine(castPoint.position, endPosTop, Color.blue);
        Debug.DrawLine(castPoint.position, endPosDown, Color.cyan);
        return val;
    }

    public void Patrolling()
    {
        //GameObject EnemyGun = GameObject.Find("EnemyGun");
        //EnemyGun.GetComponent<EnemyGun>().enabled = false;

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

    public void Shooting()
    {
        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > 1)     //delay shooting so when it see's u it waits x secs b4 firing first bullet
        {
            TimeToFire();

            timerReached = false;            //Set to false so that We don't run this again
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
        //GameObject EnemyGun = GameObject.Find("EnemyGun");
        //EnemyGun.GetComponent<EnemyGun>().enabled = false;

        fireRate = 1f;
        nextFire = Time.time;

    }

    // Update is called once per frame
    public void Update()
    {
        //float distToPlayer = Vector2.Distance(transform.position, Player.position);

        if (!CanSeePlayer(detectionRange))
        {
            Patrolling();

        }
        else if (CanSeePlayer(detectionRange))
        {
            Shooting();

        }   

    }

}
