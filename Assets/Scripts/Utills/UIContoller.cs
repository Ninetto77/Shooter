using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContoller : MonoBehaviour
{
    [SerializeField] private Text scoretext;
    [SerializeField] private SettingPopup settingPopup;
    private int score;

    private void Start()
    {
        score = 0;
        scoretext.text = score.ToString();

        settingPopup.ClosePopup();
        GlobalEventManager.OnEnemyKilled.AddListener(OnEnemyHit);
    }

    public void OnEnemyHit()
    {
        score++;
        scoretext.text = score.ToString();
    }

    //void Update()
    //{
    //    scoretext.text = Time.realtimeSinceStartup.ToString(); //время с начала запуска игры
    //}

    public void OnOpenSettings()
    {
        settingPopup.OpenPopup();
    }

    public void OnCloseSettings()
    {
        settingPopup.ClosePopup();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer donw");
    }



}
