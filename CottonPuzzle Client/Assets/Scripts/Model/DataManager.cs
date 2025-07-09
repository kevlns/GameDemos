using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private Dictionary<string, int> m_BackPack = new Dictionary<string, int>();
    public IReadOnlyDictionary<string, int> BackPack => m_BackPack;

    public event Action BackPackUpdatedEvent;

    public void AddItem(string itemName, int count)
    {
        if (m_BackPack.ContainsKey(itemName))
        {
            m_BackPack[itemName] += count;
        }
        else
        {
            m_BackPack.Add(itemName, count);
        }

        BackPackUpdatedEvent?.Invoke();
    }

    public void RemoveItem(string itemName, int count)
    {
        if (m_BackPack.ContainsKey(itemName))
        {
            m_BackPack[itemName] -= count;
            if (m_BackPack[itemName] <= 0)
            {
                m_BackPack.Remove(itemName);
            }
        }

        BackPackUpdatedEvent?.Invoke();
    }

    public int GetItemCount(string itemName)
    {
        int count;
        if (!m_BackPack.TryGetValue(itemName, out count))
            return 0;
        return count;
    }

    public bool ConsumeItem(string itemName, int count)
    {
        if (m_BackPack.ContainsKey(itemName))
        {
            if (m_BackPack[itemName] >= count)
            {
                m_BackPack[itemName] -= count;
                if (m_BackPack[itemName] <= 0)
                {
                    m_BackPack.Remove(itemName);
                }

                BackPackUpdatedEvent?.Invoke();
                return true;
            }
        }

        return false;
    }
}