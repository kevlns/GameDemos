using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class HomeContents : MonoBehaviour
{
    public Button m_NewGameButton;
    
    // Start is called before the first frame update
    void Start()
    {
        m_NewGameButton.GetComponent<Button>().onClick.AddListener(OnNewGameBtnClicked);
    }

    void OnNewGameBtnClicked()
    {
        // todo 新建存档，新开游戏
        Addressables.LoadSceneAsync("H1");
    }
}
