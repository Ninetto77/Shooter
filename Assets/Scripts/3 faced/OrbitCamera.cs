using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 3.0f;

    private float _rotY;
    private Vector3 _offset;


    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset =  target.position- transform.position; //вектор смещения
    }

    void LateUpdate()
    {
        float horMove = Input.GetAxis("Horizontal");
        if (horMove != 0)
        {
            _rotY += horMove * rotSpeed;
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 2;
        }

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset); // умножаем вектор смещения на кватернион, и вычитаем это из положения игрока
        transform.LookAt(target);
    }
}
