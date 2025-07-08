using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PropBar : MonoBehaviour
{
    public Image m_CurProp;
    public TextMeshProUGUI m_PropHint;
    private int m_CurPropIndex = 0;
    private Dictionary<string, string> m_SpriteUINames = new Dictionary<string, string>();

    private void Awake()
    {
        m_SpriteUINames["prop_kep"] = "信箱钥匙";
        GameManager.Instance.OnBackPackUpdate += RefreshPropBar;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 默认显示第一个道具
        if (GameManager.Instance.backPack.Count > 0)
        {
            m_CurProp.sprite = GameManager.Instance.backPack[m_CurPropIndex];
            m_PropHint.text = m_SpriteUINames[m_CurProp.sprite.name];
        }
    }

    void RefreshPropBar()
    {
        if (m_CurProp == null)
        {
            m_CurProp.sprite = GameManager.Instance.backPack[m_CurPropIndex];
            m_PropHint.text = m_SpriteUINames[m_CurProp.sprite.name];
        }
    }
}