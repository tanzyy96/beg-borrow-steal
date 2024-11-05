using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - target.position; // Move the camera to the target's position
    }

    void FixedUpdate()
    {
        transform.position = target.position + cameraOffset; // Move the camera to the target's position
    }
}
