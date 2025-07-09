using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.OpenUIView("StartMenu");
    }
}
