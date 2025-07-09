using System;
using UnityEngine;

public class MouseManager : Singleton<MouseManager>
{
    public Texture2D m_CollectState;

    private Camera m_Camera;
    private RaycastHit m_Hit;

    public event Action<GameObject> OnClicked;

    protected override void Awake()
    {
        base.Awake();
        m_Camera = Camera.main;
    }

    private void Update()
    {
        ScanActions();
        MouseControl();
    }

    private void ScanActions()
    {
        if (Physics.Raycast(m_Camera.ScreenPointToRay(Input.mousePosition), out m_Hit))
        {
            if (m_Hit.collider.CompareTag("Collectable"))
                Cursor.SetCursor(m_CollectState, new Vector2(0.5f, 0.5f), CursorMode.Auto);
            else
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        else
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && m_Hit.collider != null)
        {
            if (m_Hit.collider.gameObject != null)
                OnClicked?.Invoke(m_Hit.collider.gameObject);
        }
    }
}