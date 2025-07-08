using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [HideInInspector] public GameObject m_MainUI;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>("MainUI").Completed += (handle) =>
        {
            m_MainUI = Instantiate(handle.Result, transform);
        };
    }

    // Update is called once per frame
    void Update()
    {
    }
}