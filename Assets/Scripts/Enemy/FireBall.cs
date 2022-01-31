using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 3.0f;
    public int damage = 1;

 
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            player.Hurt(damage);
        }
        Debug.LogError("FIREBALL IS DESTROYED BY " + other.name);
        Destroy(gameObject);
    }
}
