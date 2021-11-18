using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] 
    public float speed = 15f;
    public Rigidbody2D rb;

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
        if (collision.gameObject.name.Equals ("Player"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
        else if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
