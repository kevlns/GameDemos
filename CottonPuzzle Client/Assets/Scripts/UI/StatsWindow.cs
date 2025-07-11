using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class StatsWindow : MonoBehaviour
{
    public Button m_LeftButton;
    public Button m_RightButton;
    public Button m_PropButton;
    public Image m_PropImg;
    public TextMeshProUGUI m_PropHintText;
    public Image m_LeftArrowImg;
    public Image m_RightArrowImg;

    private Dictionary<string, Sprite> m_NameToSprite = new Dictionary<string, Sprite>();
    private int m_CurSpriteViewIndex;
    private Sprite m_LeftArrowEnableSprite;
    private Sprite m_RightArrowEnableSprite;
    private Sprite m_LeftArrowDisableSprite;
    private Sprite m_RightArrowDisableSprite;

    private Dictionary<string, string> m_Hints = new Dictionary<string, string>
    {
        { "prop_key", "MailBox Key" }
    };

    private void Awake()
    {
        // TODO 读档

        m_LeftButton.onClick.AddListener(OnLeftBtnClicked);
        m_RightButton.onClick.AddListener(OnRightBtnClicked);
        m_PropButton.onClick.AddListener(OnPropBtnClicked);
        m_CurSpriteViewIndex = 0;

        SpriteUtil.LoadSprite("left_arrow", (sprite) =>
        {
            m_LeftArrowEnableSprite = sprite;
            RefreshView();
        });
        SpriteUtil.LoadSprite("right_arrow", (sprite) =>
        {
            m_RightArrowEnableSprite = sprite;
            RefreshView();
        });
        SpriteUtil.LoadSprite("left_arrow_disable", (sprite) =>
        {
            m_LeftArrowDisableSprite = sprite;
            RefreshView();
        });
        SpriteUtil.LoadSprite("right_arrow_disable", (sprite) =>
        {
            m_RightArrowDisableSprite = sprite;
            RefreshView();
        });

        DataManager.Instance.BackPackUpdatedEvent += RefreshView;
    }

    private void OnDisable()
    {
        if (DataManager.IsInitialized()) DataManager.Instance.BackPackUpdatedEvent -= RefreshView;
    }

    void RefreshView()
    {
        foreach (var Pair in DataManager.Instance.BackPack)
        {
            if (!m_NameToSprite.ContainsKey(Pair.Key))
            {
                m_NameToSprite.Add(Pair.Key, null);
                SpriteUtil.LoadSprite(Pair.Key, (sprite) =>
                {
                    if (sprite != null)
                    {
                        m_NameToSprite[Pair.Key] = sprite;
                        if (m_CurSpriteViewIndex >= 0 && m_CurSpriteViewIndex < m_NameToSprite.Count)
                        {
                            m_PropImg.sprite = m_NameToSprite.ElementAt(m_CurSpriteViewIndex).Value;
                            m_PropHintText.text = m_Hints[m_PropImg.sprite.name];
                            m_PropImg.color = new Color(1, 1, 1, 1);
                            m_PropImg.preserveAspect = true;
                        }
                    }
                });
            }
        }

        if (m_CurSpriteViewIndex > 0)
        {
            m_LeftArrowImg.sprite = m_LeftArrowEnableSprite;
            m_LeftButton.enabled = true;
        }
        else
        {
            m_LeftArrowImg.sprite = m_LeftArrowDisableSprite;
            m_LeftButton.enabled = false;
        }

        if (m_CurSpriteViewIndex < m_NameToSprite.Count - 1)
        {
            m_RightArrowImg.sprite = m_RightArrowEnableSprite;
            m_RightButton.enabled = true;
        }
        else
        {
            m_RightArrowImg.sprite = m_RightArrowDisableSprite;
            m_RightButton.enabled = false;
        }
    }

    void OnLeftBtnClicked()
    {
    }

    void OnRightBtnClicked()
    {
    }

    void OnPropBtnClicked()
    {
    }
}