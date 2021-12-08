using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesManagerCOMPLETE : MonoBehaviour
{
    [SerializeField] Image image;

    [SerializeField] AssetReference assetReference;
    [SerializeField] AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] AssetReferenceSprite assetReferenceSprite;
    


    public void AddressablesPrefab()
    {
        Addressables.InstantiateAsync(assetReferenceGameObject);
    }

    public void AddressablesScene()
    {
        assetReference.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void AddressablesSprite()
    {
        assetReferenceSprite.LoadAssetAsync().Completed += OnSpriteLoaded;
    }

    void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        image.sprite = handle.Result;
    }
}
