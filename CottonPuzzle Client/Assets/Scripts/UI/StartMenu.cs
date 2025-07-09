using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button m_NewGameBtn;

    private void Awake()
    {
        m_NewGameBtn.onClick.AddListener(OnNewGameBtnClicked);
    }

    void OnNewGameBtnClicked()
    {
        SceneController.Instance.ChangeScene("H1");
        UIManager.Instance.CloseUIView("StartMenu");
        UIManager.Instance.OpenUIView("StatsWindow");
    }
}