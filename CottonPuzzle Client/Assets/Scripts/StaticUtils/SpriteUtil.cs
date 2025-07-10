using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpriteUtil : MonoBehaviour
{
    public static void LoadSprite(string fileKey, System.Action<Sprite> onLoaded)
    {
        Addressables.LoadAssetAsync<Sprite>(fileKey).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                onLoaded?.Invoke(handle.Result);
            }
            else
            {
                Debug.LogError($"Failed to load sprite with key: {fileKey}");
                onLoaded?.Invoke(null);
            }
        };
    }
}