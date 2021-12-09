using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAtlasLoader : MonoBehaviour
{
    public AssetReferenceAtlasedSprite newAtlasedSprite;
    public string spriteAtlasAddress;
    public string atlasedSpriteName;
    public bool useAtlasedSpriteName;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (useAtlasedSpriteName)
        {
            string atlasedSpriteAddress = spriteAtlasAddress + '[' + atlasedSpriteName + ']';
            Debug.Log("atlasedSpriteAddress: " + atlasedSpriteAddress);
            Addressables.LoadAssetAsync<SpriteAtlas>(atlasedSpriteAddress).Completed += SpriteAtlasLoaded;
        }
        else
            newAtlasedSprite.LoadAssetAsync().Completed += SpriteLoaded;
    }

    private void SpriteAtlasLoaded(AsyncOperationHandle<SpriteAtlas> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                spriteRenderer.sprite = obj.Result.GetSprite(atlasedSpriteName);
                break;
            case AsyncOperationStatus.Failed:
                Debug.LogError("Sprite load failed. Using default Sprite.");
                break;
            default:
                // case AsyncOperationStatus.None:
                break;
        }
    }

    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                spriteRenderer.sprite = obj.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.LogError("Sprite load failed");
                break;
            default: break;
        }
    }


}
