using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private string m_SaveRoot;

    protected override void Awake()
    {
        base.Awake();
        m_SaveRoot = Application.persistentDataPath + "/.DS";
    }

    public T Load<T>(string modelName) where T : class
    {
        string filePath = GetSaveRoot() + modelName + ".json";

        if (!System.IO.File.Exists(filePath))
        {
            Debug.LogWarning($"文件不存在: {filePath}");
            return null;
        }

        try
        {
            string json = System.IO.File.ReadAllText(filePath);
            T data = JsonUtility.FromJson<T>(json);

            if (data == null)
                Debug.LogError($"反序列化失败: {filePath}，可能JSON格式不匹配");

            return data;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"读取或解析文件时出错: {filePath}\n{ex.Message}");
            return null;
        }
    }

    public void Save(string sceneName)
    {
        GameObject modelGo = GameObject.Find(sceneName);
        if (modelGo != null)
        {
            if (modelGo.CompareTag("H2A"))
                modelGo.GetComponent<H2AModel>().Save();

            // TODO 其他场景
        }
        else
        {
            Debug.LogError("Can't find GameObject: " + sceneName);
        }
    }

    public string GetSaveRoot()
    {
        if (!System.IO.Directory.Exists(m_SaveRoot))
            System.IO.Directory.CreateDirectory(m_SaveRoot);
        return m_SaveRoot + "/";
    }
}