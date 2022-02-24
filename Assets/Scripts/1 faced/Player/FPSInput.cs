using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour
{
   public float speed = 9f;
   private float baseSpeed = 9f;
   private float gravity= -9.8f;
   private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        GlobalEventManager.OnSpeedChanged.AddListener(OnSpeedChange);
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);

    }

    public void OnSpeedChange(float value)
    {
        speed = value * baseSpeed;
    }
}
