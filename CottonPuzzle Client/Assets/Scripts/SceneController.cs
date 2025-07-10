using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public void ChangeScene(string to, string from = null)
    {
        StartCoroutine(_ChangeScene(to, from));
    }

    private IEnumerator _ChangeScene(string to, string from = null)
    {
        if (!string.IsNullOrEmpty(from))
        {
            SaveManager.Instance.Save(from);
            yield return SceneManager.UnloadSceneAsync(from);
        }

        yield return Addressables.LoadSceneAsync(to, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
    }
}