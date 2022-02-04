using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    public float rotSpeed;
    public float speed;

    public float JumpForce; 
    public float TerminalVelocity = -10.0f;
    public float MinFall = -1.5f;


    [SerializeField] private Transform target;
    private float gravity = -9.8f;
    private Vector3 movement;
    private float vertSpeed;
    private CharacterController _characterController;
    private bool hitGround = false;
    private ControllerColliderHit _contact;

    void Start()
    {
        vertSpeed = MinFall;
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput *speed;
            movement.z = vertInput * speed;
            movement = Vector3.ClampMagnitude(movement, speed);


            // чтобы игрок шел по направлению относительно экрана
            Quaternion temp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);         //из локальных переменных в глобальные
            target.rotation = temp;

            Quaternion direction = Quaternion.LookRotation(movement); 
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed*Time.deltaTime);
        }

        hitGround = false;
        RaycastHit hit;
        if (vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_characterController.height + _characterController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }

        if (hitGround == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = JumpForce;
            }
            else
            {
                vertSpeed = MinFall;
            }
        }
        else
        {
            vertSpeed += gravity * Time.deltaTime * 5;
            if (vertSpeed <= TerminalVelocity)
            {
                vertSpeed = TerminalVelocity;
            }
            if (_characterController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)     //скалярное произведение. -1 противоположеное направление, 1 - коллериальные
                {
                    movement = _contact.normal * speed;
                }
                else
                {
                    movement += _contact.normal * speed;
                }
            }
        }

        movement.y = vertSpeed;
        movement *= Time.deltaTime;
        _characterController.Move(movement);
    }

    void OnControllerColliderHit (ControllerColliderHit hit)
    {
        _contact = hit;
    }
}
