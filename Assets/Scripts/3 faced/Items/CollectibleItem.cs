using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{        
    [SerializeField] private string itemName;
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collect Item");
            Managers.Inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}
