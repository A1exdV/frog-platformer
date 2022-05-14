using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Transform cam;
    private void Start()
    {
        cam = transform;
    }

    void Update()
    {
        var position = cam.position;
        position = new Vector3(player.position.x,position.y,position.z);
        cam.position = position;
    }
}
