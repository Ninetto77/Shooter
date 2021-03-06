using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public void ReactHit()
    {
        WarderingAI behavior = GetComponent<WarderingAI>();
        if (behavior == true)
        {
            behavior.SetActive(false);
        }
        StartCoroutine(Die());
        GlobalEventManager.SendEnemyKilled();
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    
    }
}
