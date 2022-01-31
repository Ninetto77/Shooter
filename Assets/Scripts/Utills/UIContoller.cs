using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContoller : MonoBehaviour
{
    [SerializeField] private Text scoretext;

    void Update()
    {
        scoretext.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        Debug.Log("open settings");
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer donw");
    }
}
