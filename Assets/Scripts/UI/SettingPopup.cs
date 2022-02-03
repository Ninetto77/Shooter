using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private const float baseSpeed = 6.0f;

    private void Start()
    {
         slider.value = PlayerPrefs.GetInt("speed", 1);
    }
    public void OpenPopup()
    {
        gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log("Name: " + name);
        PlayerPrefs.SetString("Name", name);
    }

    public void OnSpeedValue(float value)
    {
        GlobalEventManager.SendSpeedChanged(value);
    }
}
