using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
