using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2Model : MonoBehaviour
{
    public GameObject m_H2A;
    public GameObject m_H2toH3;

    private void Start()
    {
        if (SaveManager.Instance.Cache.H2AModelDataCache != null && SaveManager.Instance.Cache.H2AModelDataCache.IsPass)
        {
            m_H2A.SetActive(false);
            m_H2toH3.SetActive(true);
        }
    }
}