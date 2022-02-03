using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireBallPrefab;
    private GameObject _fireBall;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private float baseSpeed = 3.0f;
    private float radiusSphere = 0.75f;
    private bool isAlive = true;

    private void Start()
    {
        GlobalEventManager.OnSpeedChanged.AddListener(OnSpeedChange);
    }

    void Update()
    {
        if (isAlive == false)
        {
            return;
        }
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, radiusSphere, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            PlayerController _player = hitObject.GetComponent<PlayerController>();
            if (_player)
            {
                if (_fireBall == null)
                {
                    _fireBall = Instantiate(fireBallPrefab) as GameObject;
                   _fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f + Vector3.up*0.3f);
                    _fireBall.transform.rotation = transform.rotation;
                }
        }
        else
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetActive(bool _isAlive)
    {
        isAlive = _isAlive;
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    private void OnSpeedChange(float value)
    {
        speed = value * baseSpeed;
        PlayerPrefs.SetFloat("Enemy Speed", speed);
    }
}
