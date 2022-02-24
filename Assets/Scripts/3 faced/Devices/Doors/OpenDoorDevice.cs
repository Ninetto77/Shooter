using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorDevice : DeviceInterface
{
    [SerializeField] private Vector3 doorPos;
    private bool isOpen = false;
    private Animator _animator;
    public float speed = 15.0f;

    public override void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void Operate()
    {

        if (!isOpen)
        {
            Debug.Log("Open");
            Vector3 pos = transform.position + doorPos;
            transform.position = pos;
            //_animator.SetBool("IsOpen", true);
        }
        else
        {
            Debug.Log("Close");
            Vector3 pos = transform.position - doorPos;
            transform.position = pos;
            //_animator.SetBool("IsOpen", false);
        }
        isOpen = !isOpen;
    }


}
