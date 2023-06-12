using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnerCloudR : MonoBehaviour
{

    // [SerializeField] private GameObject _prefab;
    [SerializeField] private AssetReference _robot;
    
    
    // Start is called before the first frame update
    void Start()
    {

        var asyncOperantionHandle = _robot.LoadAssetAsync<GameObject>(); //cargar de disco a memoria el objeto que le indiquemos
        asyncOperantionHandle.Completed += OnCompleted;
    }

    
    private void OnCompleted(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Completed");
    }


}
