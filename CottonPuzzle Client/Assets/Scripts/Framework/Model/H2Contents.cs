using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class H2Contents : MonoBehaviour
{
    public Image m_SceneImage;
    public Button m_ToH1Button;
    public Button m_ToH2AButton;
    public Button m_ToH4Button;
    public Button m_KeyButton;

    private GameObject g_GameManager;

    // Start is called before the first frame update
    void Start()
    {
        // todo 从 GameManager 还原场景

        Addressables.LoadAssetAsync<Sprite>("H2_default").Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
                m_SceneImage.sprite = handle.Result;
        };

        m_ToH1Button.GetComponent<Button>().onClick.AddListener(OnToH1BtnClicked);
        m_ToH2AButton.GetComponent<Button>().onClick.AddListener(OnToH2ABtnClicked);
        m_ToH4Button.GetComponent<Button>().onClick.AddListener(OnToH4BtnClicked);
        m_KeyButton.GetComponent<Button>().onClick.AddListener(OnKeyPropClicked);
    }

    void OnToH1BtnClicked()
    {
        // todo 存储场景状态
        Addressables.LoadSceneAsync("H1");
    }

    void OnToH2ABtnClicked()
    {
        // todo 存储场景状态
        Debug.Log("To H2A");
    }

    void OnToH4BtnClicked()
    {
        // todo 存储场景状态
        Debug.Log("To H4");
    }

    void OnKeyPropClicked()
    {
        // 添加到背包
        Addressables.LoadAssetAsync<Sprite>("key_prop").Completed += (handle) =>
        {
            GameManager.Instance.backPack.Add(handle.Result);
        };

        // 删除场景元素
        Destroy(m_KeyButton.gameObject);
    }
}