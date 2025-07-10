using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2ANode : MonoBehaviour
{
    public GameObject m_UnactiveState;
    public GameObject m_ActiveState;
    public Transform TargetLocation;
    private bool m_IsActive = false;

    public void RefreshState(ref int count)
    {
        if (TargetLocation == null)
            return;

        bool flag = Vector3.SqrMagnitude(TargetLocation.position - transform.position) < 0.01f;

        if (flag && !m_IsActive)
            ++count;
        else if (!flag && m_IsActive)
            --count;

        SetActive(flag);
    }

    private void SetActive(bool flag)
    {
        m_IsActive = flag;
        if (flag)
        {
            m_ActiveState.SetActive(true);
            m_UnactiveState.SetActive(false);
        }
        else
        {
            m_ActiveState.SetActive(false);
            m_UnactiveState.SetActive(true);
        }
    }

    public bool IsActive()
    {
        return m_IsActive;
    }
}

[Serializable]
public class H2ANodeData
{
    public Vector3 Position;

    public H2ANodeData(Vector3 position)
    {
        Position = position;
    }
}