using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]public float speed = 20f;
    [SerializeField]public Rigidbody2D rb;
    [SerializeField]int damage = 40;
    
    
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

   
}
