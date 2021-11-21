using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//------------------------------------------DEAD SCRIPT!!!!!!!


/*public class EnemyGun : MonoBehaviour
{

    //Enemy shootingn declarations
    #region Enemy Shooting declarations
    [SerializeField]
    GameObject enemyBullet;

    float fireRate;
    float nextFire;
    #endregion

    float angleBetween = 2f;
    float angleUp = 5f;
    float angleDown = 5f;

    [SerializeField] Transform Player;
    [SerializeField] Transform castPoint;
    [SerializeField] float detectionRange = 5f;
    public bool facingRight;
    public bool movingRight;

    void TimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
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

    // Start is called before the first frame update
    void Start() 
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(detectionRange))
        {
            TimeToFire();

        }
    }
}*/
