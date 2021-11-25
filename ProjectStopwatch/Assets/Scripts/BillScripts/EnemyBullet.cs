using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] 
    public float speed = 13f;
    public Rigidbody2D rb;
    int damage = 40;
    
    PlayerMovement target;

    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>(); 
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.GetComponent<PlayerMovement>();
        if (!(collision.gameObject.name.Equals("Enemy")))
        {
            Destroy(gameObject);
        }
        target = collision.GetComponent<PlayerMovement>();
        if (collision.gameObject.name.Equals ("Player"))
        {
            target.TakeDamage(damage);
        }
        
    }

}
