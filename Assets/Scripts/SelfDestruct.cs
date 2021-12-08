using UnityEngine;
using UnityEngine.AddressableAssets;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] private float lifetime = 2f;

    private void Start()
    {
        Invoke("Release", lifetime);
    }

    void Release()
    {
        Addressables.ReleaseInstance(gameObject);
    }
}
