using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private LayerMask mouseCollider = new LayerMask();
    public event EventHandler<OnShootEventArgs>OnShoot;
    private Transform aimTransform;
    private Transform aimGunEnd;
    public SpriteRenderer mySpriteRenderer;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPoint;
        public Vector3 shootPosition;
    }
    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseCollider))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimGunEnd = aimTransform.Find("GunEndPoint");
    }

    private void Update()
    {
        if (PauseMenu.Paused == false)
        {
            PlayerAiming();
        }
    }

    private void PlayerAiming()
    {
        
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        if (mousePosition.x < transform.position.x)
        {
            mySpriteRenderer.flipY = true;
        }
        else if (mousePosition.x > transform.position.x)
        {
            mySpriteRenderer.flipY = false;
        }

    }

}
