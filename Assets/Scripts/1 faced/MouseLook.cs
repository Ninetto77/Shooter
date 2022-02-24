using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2

    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;

    public float minVert = -45;
    public float maxVert = 45;

    float rotation_x = 0;
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

   
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        if (axes == RotationAxes.MouseY)
        {
            rotation_x -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotation_x = Mathf.Clamp(rotation_x, minVert, maxVert);

            float rotation_y = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotation_x, rotation_y, 0);
        }
        else
        {
            rotation_x = Input.GetAxis("Mouse Y") * sensitivityVert;
            rotation_x = Mathf.Clamp(rotation_x, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotation_y = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotation_x, rotation_y, 0);
        }
    }
}
