using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]private Transform firePoint;
    [SerializeField]private GameObject bullet;
    private bool readyToShoot;
    public bool allowInvoke = true;
    [SerializeField]public float timeBetweenShooting;

    private void Awake()
    {
        readyToShoot = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.Paused == false)
        {
        
                if (readyToShoot && Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
        }
    
      
    }

    private void ResetShot()
    {

        readyToShoot = true;
        allowInvoke = true;
    }

    void Shoot()
    {
        readyToShoot = false;
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }
}
