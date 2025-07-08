using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnNewGameBtnClicked()
    {
        // todo 开启新的流程存档
        Addressables.LoadSceneAsync("H1");
    }
    
    public void OnToH1BtnClicked()
    {
        Addressables.LoadSceneAsync("H1");
    }
    
    public void OnToH2BtnClicked()
    {
        Addressables.LoadSceneAsync("H2");
    }
    
    public void OnToH2ABtnClicked()
    {
        Debug.Log("H2A");
    }
    
    public void OnToH3BtnClicked()
    {
        Debug.Log("H3");
    }
    
    public void OnToH4BtnClicked()
    {
        Debug.Log("H4");
    }
    
    public void OnKeyBtnClicked()
    {
        Debug.Log("Key");
    }
}
