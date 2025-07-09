using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UIManager : Singleton<UIManager>
{
    private GameObject m_UIRootCanvas;
    private Transform m_UIRootTransform;
    private Dictionary<string, GameObject> m_OpenedUIViews = new Dictionary<string, GameObject>();

    // TODO ui队列
    private Queue<GameObject> m_UIQueue = new Queue<GameObject>();

    protected override void Awake()
    {
        base.Awake();

        m_UIRootCanvas = GameObject.Find("UIRootCanvas");
        if (m_UIRootCanvas != null)
            m_UIRootTransform = m_UIRootCanvas.transform;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        foreach (var Pair in m_OpenedUIViews)
        {
            Destroy(Pair.Value);
        }

        m_OpenedUIViews.Clear();
    }

    Transform GetUIRootTransform()
    {
        return m_UIRootTransform;
    }

    public void OpenUIView(string uiViewName, Transform parent = null)
    {
        Addressables.LoadAssetAsync<GameObject>(uiViewName).Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Transform trans = parent != null ? parent : m_UIRootTransform;
                GameObject ui = Instantiate(handle.Result, trans);
                m_OpenedUIViews.Add(uiViewName, ui);
            }
            else
            {
                Debug.LogError("Can't Open UI: " + uiViewName);
            }
        };
    }

    public void CloseUIView(string uiViewName)
    {
        if (m_OpenedUIViews.ContainsKey(uiViewName))
        {
            m_OpenedUIViews[uiViewName].SetActive(false);
        }
    }
}