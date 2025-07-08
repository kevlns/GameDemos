using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class H1Contents : MonoBehaviour
{
    public Button m_ToH2Button;

    // Start is called before the first frame update
    void Start()
    {
        GameObject buttonEventsGo = GameObject.Find("ButtonEvents");
        if (buttonEventsGo != null)
        {
            ButtonEvents buttonEvents = buttonEventsGo.GetComponent<ButtonEvents>();
            m_ToH2Button.GetComponent<Button>().onClick.AddListener(buttonEvents.OnToH2BtnClicked);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}