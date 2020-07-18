using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing);
        }
    }
}
