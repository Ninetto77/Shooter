using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in hitColliders)
            {
                if (collider.gameObject.tag == "Device")
                {
                    Vector3 direction = collider.transform.position - transform.position;
                    if (Vector3.Dot(Vector3.forward, direction) > 0.5f)
                    {
                        DeviceInterface device = collider.GetComponent<DeviceInterface>();
                        device.Operate();
                    }
                }
            }
        }
    }
}
