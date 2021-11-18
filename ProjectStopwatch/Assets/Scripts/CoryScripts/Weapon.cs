using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]private Transform firePoint;
    [SerializeField]private GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.Paused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
