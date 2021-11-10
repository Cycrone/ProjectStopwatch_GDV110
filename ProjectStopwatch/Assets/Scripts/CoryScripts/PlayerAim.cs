using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class PlayerAim : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs>OnShoot;
    private Transform aimTransform;
    private Transform aimGunEnd;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPoint;
        public Vector3 shootPosition;
    }

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimGunEnd = aimTransform.Find("GunEndPoint");
    }

    private void Update()
    {
        PlayerAiming();
    }

    private void PlayerAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

}
