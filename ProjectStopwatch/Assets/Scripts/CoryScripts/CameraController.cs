using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform CamFollow;

    private void Update()
    {
        transform.position = new Vector3(CamFollow.position.x, CamFollow.position.y, transform.position.z);
    }
}
