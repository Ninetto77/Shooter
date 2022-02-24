using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeviceTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerZone;
    public bool requireKey;

    private void OnTriggerEnter(Collider other)
    {
        if (requireKey && Managers.Inventory.equippedItem != "key")
        {
            return;
        }
        OnTriggerZone.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        //OnTriggerZone.Invoke();
    }
}
