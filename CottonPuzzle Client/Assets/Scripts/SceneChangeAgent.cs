using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeAgent : MonoBehaviour
{
    private void Start()
    {
        MouseManager.Instance.OnClicked += OnClicked;
    }

    private void OnDisable()
    {
        if (MouseManager.Instance != null) MouseManager.Instance.OnClicked -= OnClicked;
    }

    private void OnClicked(GameObject go)
    {
        if (go != gameObject) return;

        if (CompareTag("H1toH2"))
            SceneController.Instance.ChangeScene("H2", "H1");
        else if (CompareTag("H2toH1"))
            SceneController.Instance.ChangeScene("H1", "H2");
        else if (CompareTag("H2toH2A"))
            SceneController.Instance.ChangeScene("H2A", "H2");
        else if (CompareTag("H2toH4"))
            SceneController.Instance.ChangeScene("H4", "H2");
        else if (CompareTag("H2AtoH2"))
            SceneController.Instance.ChangeScene("H2", "H2A");
        else if (CompareTag("H4toH2"))
            SceneController.Instance.ChangeScene("H2", "H4");
        else if (CompareTag("H3toH2"))
            SceneController.Instance.ChangeScene("H2", "H3");
    }
}