using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    private void Start()
    {
    }

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; // по умолчанию это тип Object
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

            WarderingAI warderingAI;
            warderingAI = _enemy.GetComponent<WarderingAI>();
            if (warderingAI)
            {
                warderingAI.speed = PlayerPrefs.GetFloat("Enemy Speed", warderingAI.GetBaseSpeed());
            }
        }
    }

    private void OnDestroy()
    {
        WarderingAI warderingAI;
        warderingAI = _enemy.GetComponent<WarderingAI>();
        if (warderingAI)
        {
             PlayerPrefs.SetFloat("Enemy Speed", warderingAI.GetBaseSpeed());       
        }
    }
}
