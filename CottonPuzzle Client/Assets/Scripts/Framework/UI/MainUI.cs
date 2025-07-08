using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public GameObject m_PropBarGo;
    private PropBar m_PropBar;
    
    // Start is called before the first frame update
    void Start()
    {
        m_PropBar = m_PropBarGo.GetComponent<PropBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
