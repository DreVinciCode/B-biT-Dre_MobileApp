using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_Object : MonoBehaviour
{
    float rotSpeed = 20;

    void OnMouseDrag()
    {
        float rotx = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float roty = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotx);
        transform.RotateAround(Vector3.right, -roty);

    }
}
