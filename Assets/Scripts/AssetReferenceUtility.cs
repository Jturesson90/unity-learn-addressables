using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetReferenceUtility : MonoBehaviour
{
    public AssetReference objectToLoad;
    public AssetReference accessoryObjectToLoad;

    private GameObject instantiatedObject;
    private GameObject instantiatedAccessoryObject;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(objectToLoad).Completed += ObjectLoadDone;
    }

    private void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status != AsyncOperationStatus.Succeeded) return;

        GameObject loadedObject = obj.Result;
        Debug.Log("Successfully loaded object.");
        instantiatedObject = Instantiate(loadedObject);
        Debug.Log("Successfully instantiated object.");
        
        if (!accessoryObjectToLoad.RuntimeKeyIsValid()) return;

        accessoryObjectToLoad.InstantiateAsync(instantiatedObject.transform).Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                instantiatedAccessoryObject = op.Result;
                Debug.Log("Successfully loaded and instantiated accessory object.");
            }
        };

    }
}
