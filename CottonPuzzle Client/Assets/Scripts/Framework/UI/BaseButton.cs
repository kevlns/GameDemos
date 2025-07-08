using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    private Button m_Button;

    void Awake()
    {
        m_Button = GetComponent<Button>();
    }

    void Start()
    {
        GameObject buttonEventsGo = GameObject.Find("ButtonEvents");
        if (buttonEventsGo != null)
        {
            ButtonEvents buttonEvents = buttonEventsGo.GetComponent<ButtonEvents>();

            if (gameObject.CompareTag("NewGameButton"))
                m_Button.onClick.AddListener(buttonEvents.OnNewGameBtnClicked);
            if (gameObject.CompareTag("ToH1Button"))
                m_Button.onClick.AddListener(buttonEvents.OnToH1BtnClicked);
            if (gameObject.CompareTag("ToH2AButton"))
                m_Button.onClick.AddListener(buttonEvents.OnToH2ABtnClicked);
            if (gameObject.CompareTag("ToH2Button"))
                m_Button.onClick.AddListener(buttonEvents.OnToH2BtnClicked);
            if (gameObject.CompareTag("ToH3Button"))
                m_Button.onClick.AddListener(buttonEvents.OnToH3BtnClicked);
            if (gameObject.CompareTag("ToH4Button"))
                m_Button.onClick.AddListener(buttonEvents.OnToH4BtnClicked);
        }
    }
}