using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;

    public float speed = 0.05f;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }

}
