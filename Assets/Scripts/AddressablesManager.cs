using UnityEngine;
using UnityEngine.UI;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] Image image;

    public void AddressablesPrefab()
    {
        Debug.Log("Load Addressables Prefab");
    }

    public void AddressablesScene()
    {
        Debug.Log("Load Addressables Scene");
    }

    public void AddressablesSprite()
    {
        Debug.Log("Load Addressables Sprite");
    }

}
