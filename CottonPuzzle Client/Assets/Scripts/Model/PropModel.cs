using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropModel : MonoBehaviour
{
    private SpriteRenderer m_PropRenderer;
    private BoxCollider m_PropCollider;

    private void Awake()
    {
        m_PropRenderer = GetComponent<SpriteRenderer>();
        m_PropCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        MouseManager.Instance.OnClicked += OnClicked;
    }

    private void OnDisable()
    {
        MouseManager.Instance.OnClicked -= OnClicked;
    }

    private void OnClicked(GameObject go)
    {
        if (go != gameObject) return;

        DataManager.Instance.AddItem(m_PropRenderer.sprite.name, 1);
        Destroy(gameObject);
    }
}