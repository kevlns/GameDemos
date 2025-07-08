using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Sprite> backPack = new List<Sprite>();
    private int m_BackPackIndex = 0;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // todo 读档
    }
}