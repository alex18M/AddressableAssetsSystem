using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] 
    private float _lifetime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Release), _lifetime);
    }

    // Update is called once per frame
    private void Release()
    {
        Addressables.ReleaseInstance(gameObject);
        Destroy(gameObject);
    }
}
