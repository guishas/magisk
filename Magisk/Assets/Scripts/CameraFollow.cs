using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // the object to follow
    public Vector3 offset; // the offset of the camera from the target object

    void FixedUpdate()
    {
        transform.position = target.position + offset; // set the position of the camera to the target position plus the offset
    }
}
