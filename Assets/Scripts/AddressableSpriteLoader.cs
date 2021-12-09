using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteRenderer))]
public class AddressableSpriteLoader : MonoBehaviour
{
    public AssetReferenceSprite newSprite;
    private SpriteRenderer spriteRenderer;

    public string newSpriteAddress;
    public bool useAddress;
    private bool loadedWithAddress;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (useAddress)
        {
            loadedWithAddress = true;
            Addressables.LoadAssetAsync<Sprite>(newSpriteAddress).Completed += SpriteLoaded;
        }
        else
        {
            newSprite.LoadAssetAsync().Completed += SpriteLoaded;
        }
    }
    private void OnDestroy()
    {
        if (loadedWithAddress)
        {
            Addressables.LoadAssetAsync<Sprite>(newSpriteAddress).Completed += SpriteLoaded;
        }
        else
        {
            newSprite.LoadAssetAsync().Completed -= SpriteLoaded;
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
