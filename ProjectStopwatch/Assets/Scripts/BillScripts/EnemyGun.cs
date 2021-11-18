using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    //Enemy shootingn declarations
    #region Enemy Shooting declarations
    [SerializeField]
    GameObject enemyBullet;

    float fireRate;
    float nextFire;
    #endregion

    void TimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    // Start is called before the first frame update
    void Start() 
    {
        fireRate = 1.2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        TimeToFire();
    }
}
